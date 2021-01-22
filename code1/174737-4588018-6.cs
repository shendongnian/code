    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
        // draw clear GlowTarget and draw normal, non-glowing objects to set depth buffer
        GraphicsDevice.SetRenderTarget(GlowTarget);
        GraphicsDevice.Clear(ClearOptions.DepthBuffer | ClearOptions.Stencil | ClearOptions.Target, Color.FromNonPremultiplied(0, 0, 0, 0), 1f, 0);
        MyScene.DrawNormal();
    
        // clear target only and set color to black WITH ZERO ALPHA, then draw glowing objects
        // so they will be the only ones that appear and they will be hidden by objects in front of them
        GraphicsDevice.Clear(ClearOptions.Target, Color.FromNonPremultiplied(0, 0, 0, 0), 1f, 0);
        MyScene.DrawGlow();
    
        // blur objects horizontally into GlowTarget2
        GraphicsDevice.SetRenderTarget(GlowTarget2);
        GraphicsDevice.Clear(Color.FromNonPremultiplied(0, 0, 0, 0));
        using (SpriteBatch sb = new SpriteBatch(GlowTarget2.GraphicsDevice))
        {
            blurXEffect.Parameters["PixelSize"].SetValue((float)(1.0f / (float)GlowTarget.Width));
            sb.Begin(0, BlendState.Additive, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone, blurXEffect);
            sb.Draw(GlowTarget, new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            sb.End();
        }
    
        // now reset context and clear for actual drawing
        GraphicsDevice.SetRenderTarget(null);
        GraphicsDevice.BlendState = BlendState.Opaque;
        GraphicsDevice.Clear(Color.Black);
    
        // TODO: Add your drawing code here
        base.Draw(gameTime);
    
        // draw scene to graphics card back buffer
        MyScene.DrawNormal();
    
        using (SpriteBatch sprite = new SpriteBatch(GraphicsDevice))
        {
            // draw glowing texture and blur Y this time
            blurYEffect.Parameters["PixelSize"].SetValue((float)(1.0f / (float)GlowTarget.Height));
            sprite.Begin(0, BlendState.Additive, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone, blurYEffect);
    
            //sprite.Draw(GlowTarget, new Vector2(0, 0), Color.White);
            sprite.Draw(GlowTarget2, new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            sprite.End();
        }
    }
