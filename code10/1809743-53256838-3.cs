    protected override void Draw(GameTime gameTime)
    {
        graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
     
        foreach (IGameObject gameObject in gameObjects)
    	{
    		gameObject.Draw();
    	}
     
        base.Draw(gameTime);
    }
