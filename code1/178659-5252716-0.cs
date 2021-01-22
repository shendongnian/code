    spritebatch.Begin();
    spritebatch.Draw(texture,
			Body.Position * Scale,
            textureSourceRectangle,
			Color.White,
			Body.Rotation,
			new Vector2(textureWidth / 2f, textureHeight / 2f),
			1f,
			SpriteEffects.None,
			0);
    spritebatch.End();
