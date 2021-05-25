using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace RottenHeart
{
		public class Game1 : Game
		{
				private GraphicsDeviceManager _graphics;
				private SpriteBatch _spriteBatch;
				
				private Texture2D _texturePertidam;
				private Vector2 _positionPertidam;

				private Texture2D _textureRock;
				private Vector2 _positionRock;

				private const int PlayerSpeed = 8;  // in px 
				private const int Gravity = 1;      // in px

				public Game1()
				{
						_graphics = new GraphicsDeviceManager(this);
						Content.RootDirectory = "Content";
						IsMouseVisible = true;
				}

				// ReSharper disable once RedundantOverriddenMember
				protected override void Initialize()
				{
						// TODO: Add your initialization logic here

						base.Initialize();
						
				}

				protected override void LoadContent()
				{
						_spriteBatch = new SpriteBatch(GraphicsDevice);
						
						_texturePertidam = Content.Load<Texture2D>("Pert");
						_positionPertidam = new Vector2(50, 50);

						_textureRock = Content.Load<Texture2D>("Rock");
						_positionRock = new Vector2(50, 50);

						// TODO: use this.Content to load your game content here
				}
				
				protected override void Update(GameTime gameTime)
				{
						if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
								Exit();

						if (Keyboard.GetState().IsKeyDown(Keys.Left)) 
							_positionPertidam.X -= PlayerSpeed;
			
						if (Keyboard.GetState().IsKeyDown(Keys.Right))
							_positionPertidam.X += PlayerSpeed;
			

						// TODO: Make the movement acceleration based, as opposed to it just being stati

						_positionPertidam.Y += Gravity;

						if (Keyboard.GetState().IsKeyDown(Keys.Space))
							_positionPertidam.Y -= 20;
							
						
						base.Update(gameTime);
				}

				protected override void Draw(GameTime gameTime)
				{
					GraphicsDevice.Clear(Color.CornflowerBlue);
					// TODO: Add your drawing code here

					_spriteBatch.Begin(SpriteSortMode.FrontToBack);
					
					// PlayerSprite Drawing
					_spriteBatch.Draw
					(
						_texturePertidam, 
						_positionPertidam, 
						null, 
						Color.White, 
						0f, 
						new Vector2(0,0), 
						1f, 
						SpriteEffects.None, 
						1
					);
					
					// Rock Drawing
					_spriteBatch.Draw
					(
						_textureRock, 
						_positionRock, 
						null, 
						Color.White, 
						0f, 
						new Vector2(0,0), 
						4f, 
						SpriteEffects.None, 
						0
					);


					_spriteBatch.End();
					
						base.Draw(gameTime);
				}
		}
}
