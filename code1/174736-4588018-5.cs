    // sprite.Begin(SpriteSortMode.Immediate, BlendState.Additive);
    sprite.Begin(0, BlendState.Additive, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone, blurEffect);
    
    //sprite.Draw(GlowTarget, new Vector2(0, 0), Color.White);
    sprite.Draw(GlowTarget3, new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
    sprite.End();
