	void DrawDesaturate(GameTime gameTime)
	{
		Effect colorMulAddEffect = desaturateEffect; // reusing desaturateEffect to keep this short!
		float pulsate = Pulsate(gameTime, 4, 0, 1);
		spriteBatch.Begin(SpriteBlendMode.None, SpriteSortMode.Immediate, SaveStateMode.None);
		colorMulAddEffect.Parameters["colorMultiply"].SetValue(new Vector4(1.5f, 1f, pulsate, 1f));
		colorMulAddEffect.Parameters["colorAdd"].SetValue(new Vector4(-0.5f, 1-pulsate, 0f, 0f));
		colorMulAddEffect.Begin();
		colorMulAddEffect.CurrentTechnique.Passes[0].Begin();
		spriteBatch.Draw(glacierTexture, FullscreenRectangle(), Color.White);
		spriteBatch.End();
		colorMulAddEffect.CurrentTechnique.Passes[0].End();
		colorMulAddEffect.End();
	}
