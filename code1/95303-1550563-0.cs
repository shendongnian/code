        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);
              
            spriteBatch.Begin();             
            GameEngine.Draw(GameEngine,gameTime); 
            spriteBatch.End();
            //resetRenderState3D();
            GameEngine.Draw3D(GameEngine, gameTime);
            base.Draw(gameTime); 
        }
