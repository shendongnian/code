    //Draw the sprite to the screen
        public void Draw(SpriteBatch theSpriteBatch)
        {
            if (mSpriteTexture != null)
            {
                theSpriteBatch.Draw(mSpriteTexture, Position,
                    new Rectangle(0, 0, mSpriteTexture.Width, mSpriteTexture.Height), Color.White,
                    0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
            }
        }
