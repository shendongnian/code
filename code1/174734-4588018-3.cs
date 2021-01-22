    // blur objects horizontally
    GraphicsDevice.SetRenderTarget(GlowTarget2);
    GraphicsDevice.Clear(Color.FromNonPremultiplied(0, 0, 0, 0));
    using (SpriteBatch sb = new SpriteBatch(GlowTarget2.GraphicsDevice))
    {
        blurXEffect.Parameters["PixelSize"].SetValue((float)(1.0f / (float)GlowTarget.Width));
        sb.Begin(0, BlendState.Additive, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone, blurXEffect);
        sb.Draw(GlowTarget, new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
        sb.End();
    }
