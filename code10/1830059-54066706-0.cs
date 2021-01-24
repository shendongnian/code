    using (Image<Rgba32> image = new Image<Rgba32>(1024, 512))
    {
        FontCollection fonts = new FontCollection();
        fonts.Install("/path/to/Neo_Sans_Medium.ttf");
    
        var verdana = SystemFonts.CreateFont("Verdana", 55);
        var neoSans = fonts.CreateFont("Neo Sans", 55);
    
        image.Mutate(x => x
            .BackgroundColor(Rgba32.White)
            .DrawText("Text with default", verdana, Rgba32.Black, new PointF(0, 0))
            .DrawText("Text with loaded font", neoSans, Rgba32.Black, new PointF(0, 65))
        );
        image.Save("out.png");
    }
