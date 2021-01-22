    // At the top of your class:
    Texture2D pixel;
     
    // Somewhere in your LoadContent() method:
    pixel = new Texture2D(GameBase.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
    pixel.SetData(new[] { Color.White }); // so that we can draw whatever color we want on top of it
