    PresentationParameters pp = GraphicsDevice.PresentationParameters;
    GraphicsDevice.DepthStencilState = DepthStencilState.Default;
    NormalTarget = new RenderTarget2D(GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight, true, SurfaceFormat.Color, DepthFormat.Depth24Stencil8);
    GlowTarget = new RenderTarget2D(GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight, true, SurfaceFormat.Color, DepthFormat.Depth24Stencil8);
    GlowTarget2 = new RenderTarget2D(GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight, true, SurfaceFormat.Color, DepthFormat.Depth24Stencil8);
    GlowTarget3 = new RenderTarget2D(GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight, true, SurfaceFormat.Color, DepthFormat.Depth24Stencil8);
