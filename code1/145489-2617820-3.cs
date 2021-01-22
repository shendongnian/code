    protected override void LoadContent()
            {
                spriteBatch = new SpriteBatch(GraphicsDevice);
    
                mSprite.Position = new Vector2(125, 245);
    
                mSpriteTwo.LoadContent(this.Content, "SquareGuy");
                mSpriteTwo.Position.X = 300;
                mSpriteTwo.Position.Y = 300;
