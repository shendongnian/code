        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice device = graphics.GraphicsDevice;
            // use game state
            switch (currentGameState)
            {
                case GameState.GameMenu:                              // load game menu and clear once enter key is pressed
                    device.Clear(Color.DarkBlue);
                    spriteBatch.Begin();
                    spriteBatch.Draw(backgroundTexture, Vector2.Zero, Color.White);
                    spriteBatch.DrawString(scoreFont, menuWelcome,
						new Vector2((float)safeBounds.Right / 2 - scoreFont.MeasureString(menuWelcome).X / 3,
						30), Color.DarkRed);
                    spriteBatch.DrawString(scoreFont, menuHowToPlay,
						new Vector2((float)safeBounds.Right / 2 - scoreFont.MeasureString(menuHowToPlay).X / 4,
						30), Color.DarkRed);
                    spriteBatch.End();
                    break;
                case GameState.GameOver:                          // load game menu and clear once escape is pressed
                    device.Clear(Color.DarkBlue);
                    spriteBatch.Begin();
                    spriteBatch.Draw(backgroundTexture, Vector2.Zero, Color.White);
                    spriteBatch.DrawString(scoreFont, GameOverText,
						new Vector2((float)safeBounds.Right / 2 - scoreFont.MeasureString(GameOverText).X / 3,
						30), Color.DarkRed);
                    spriteBatch.DrawString(scoreFont, GameOverClose,
						new Vector2((float)safeBounds.Right / 2 - scoreFont.MeasureString(GameOverClose).X / 4,
						30), Color.DarkRed);
                    spriteBatch.End();
                    device.Clear(Color.DarkBlue);
                    break;
                case GameState.GamePlay:                // load the sprite batch for main game play
				
					device.Clear(Color.CornflowerBlue);
					
                    // Open sprite batch
                    spriteBatch.Begin();
					// Draw background
					spriteBatch.Draw(backgroundTexture, Vector2.Zero, Color.White);
					// Draw character
					spriteBatch.Draw(characterTexture, characterPosition, Color.White);
					// Draw enemies
					foreach (Vector2 enemyPosition in enemyPositions)
						spriteBatch.Draw(enemyTexture, enemyPosition, enemyColor);
					// Draw on-screen game information
					spriteBatch.DrawString(scoreFont, scoreText, new Vector2(30, 30), Color.Black);
					spriteBatch.DrawString(scoreFont, highScoreText,
						new Vector2((float)safeBounds.Right - scoreFont.MeasureString(highScoreText).X,
						30), Color.Black);
					spriteBatch.DrawString(scoreFont, gameName,
						new Vector2((float)safeBounds.Right / 2 - scoreFont.MeasureString(gameName).X / 2,
						30), Color.Black);
					spriteBatch.DrawString(scoreFont, aimText,
						new Vector2((float)safeBounds.Right / 2 - scoreFont.MeasureString(gameName).X / 1,
						60), Color.Black);
					// "Close" the sprite batch
					spriteBatch.End();
					break;
            }
            base.Draw(gameTime);
        }
