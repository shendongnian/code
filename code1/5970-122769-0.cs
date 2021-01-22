    spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None);
    tintWhiteEffect.Begin();
    tintWhiteEffect.CurrentTechnique.Passes[0].Begin();
       // DRAW SPRITES HERE USING SPRITEBATCH
            
    tintWhiteEffect.CurrentTechnique.Passes[0].End();
    tintWhiteEffect.End();
            
    spriteBatch.End();
