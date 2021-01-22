    // now blur vertically
    GraphicsDevice.SetRenderTarget(GlowTarget3);
    GraphicsDevice.Clear(Color.FromNonPremultiplied(0, 0, 0, 0));
    using (SpriteBatch sb = new SpriteBatch(GlowTarget3.GraphicsDevice))
    {
        blurYEffect.Parameters["PixelSize"].SetValue((float)(1.0f / (float)GlowTarget.Width));
        sb.Begin(0, BlendState.Additive, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone, blurYEffect);
        sb.Draw(GlowTarget2, new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
        sb.End();
    }
