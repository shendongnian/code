    spriteBatch.Begin(SpriteBlendMode.AlphaBlend,
                      SpriteSortMode.FrontToBack,
                      SaveStateMode.SaveState,
                      Camera.Transform);
    spriteBatch.Draw(_heliTexture,
                     _heliPosition,
                     heliSourceRectangle,
                     Color.White,
                     0.0f,
                     new Vector2(0,0),
                     0.5f,
                     SpriteEffects.FlipHorizontally,
                     0.0f);
    spriteBatch.End();
