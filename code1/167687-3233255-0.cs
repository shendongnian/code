    // ex.
    protected override void Draw(GameTime gameTime)
    {
        // Other stuff...
        
        base.Draw(gameTime);
        // Retrieve mouse position
        MouseState mState = Mouse.GetState();
        Vector2 mousePos = new Vector2(mState.X, mState.Y);
        // Use this instead to optionally center the texture:
        // Vector2 mousePos = new Vector2(mState.X - cursorTexture.Width / 2, mState.Y - cursorTexture.Height / 2);
        // Draw cursor after base.Draw in order to draw it after any DrawableGameComponents.
        this.spriteBatch.Begin(); // Optionally save state
        this.spriteBatch.Draw(cursorTexture, mousePos, Color.White);
        this.spriteBatch.End();
    }
