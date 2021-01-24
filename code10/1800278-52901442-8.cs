    private static void CreateImageFiles()
    {
        Directory.CreateDirectory("output");
        string text = "J";
        Rgba32 backgroundColor = Rgba32.White;
        Rgba32 foregroundColor = Rgba32.Black;
        int imageWidth = 256;
        int imageHeight = 256;
        using (var finalImage = new Image<Rgba32>(imageWidth, imageHeight))
        {
            finalImage.Mutate(context => context.Fill(backgroundColor));
            finalImage.MetaData.HorizontalResolution = 96;
            finalImage.MetaData.VerticalResolution = 96;
            FontFamily fontFamily = SystemFonts.Find("Arial");
            var font = new Font(fontFamily, 10, FontStyle.Regular);
            var textGraphicOptions = new TextGraphicsOptions(true)
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                DpiX = (float)finalImage.MetaData.HorizontalResolution,
                DpiY = (float)finalImage.MetaData.VerticalResolution
            };
            SizeF size = TextMeasurer.Measure(text, new RendererOptions(font));
            float scalingFactor = finalImage.Height / size.Height;
            var scaledFont = new Font(font, scalingFactor * font.Size);
            PointF location = new PointF();
            using (Image<Rgba32> initialImage = finalImage.Clone(context => context.DrawText(textGraphicOptions, text, scaledFont, foregroundColor, location)))
            {
                initialImage.Save("output/initial.png");
                int top = GetTopPixel(initialImage, backgroundColor);
                int bottom = GetBottomPixel(initialImage, backgroundColor);
                int offset = top + (initialImage.Height - bottom);
                SizeF inflatedSize = TextMeasurer.Measure(text, new RendererOptions(scaledFont));
                float inflatingFactor = (inflatedSize.Height + offset) / inflatedSize.Height;
                var inflatedFont = new Font(font, inflatingFactor * scaledFont.Size);
                location.Offset(0.0f, -top);
                using (Image<Rgba32> intermediateImage = finalImage.Clone(context => context.DrawText(textGraphicOptions, text, inflatedFont, foregroundColor, location)))
                {
                    intermediateImage.Save("output/intermediate.png");
                    int left = GetLeftPixel(intermediateImage, backgroundColor);
                    location.Offset(-left, 0.0f);
                    finalImage.Mutate(context => context.DrawText(textGraphicOptions, text, inflatedFont, foregroundColor, location));
                    finalImage.Save("output/final.png");
                }
            }
        }
    }
    private static int GetTopPixel(Image<Rgba32> image, Rgba32 backgroundColor)
    {
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                Rgba32 pixel = image[x, y];
                if (pixel != backgroundColor)
                {
                    return y;
                }
            }
        }
        throw new InvalidOperationException("Top pixel not found.");
    }
    private static int GetBottomPixel(Image<Rgba32> image, Rgba32 backgroundColor)
    {
        for (int y = image.Height - 1; y >= 0; y--)
        {
            for (int x = image.Width - 1; x >= 0; x--)
            {
                Rgba32 pixel = image[x, y];
                if (pixel != backgroundColor)
                {
                    return y;
                }
            }
        }
        throw new InvalidOperationException("Bottom pixel not found.");
    }
    private static int GetLeftPixel(Image<Rgba32> image, Rgba32 backgroundColor)
    {
        for (int x = 0; x < image.Width; x++)
        {
            for (int y = 0; y < image.Height; y++)
            {
                Rgba32 pixel = image[x, y];
                if (pixel != backgroundColor)
                {
                    return x;
                }
            }
        }
        throw new InvalidOperationException("Left pixel not found.");
    }
