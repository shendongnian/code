    var contentControl = Resources["LocationMarker"] as ContentControl;
    if (contentControl != null)
    {
        contentControl.Measure(new Size(356, 524));
        contentControl.Arrange(new Rect(new Size(356, 524)));
        var target = new RenderTargetBitmap(
            (int)contentControl.RenderSize.Width, (int)contentControl.RenderSize.Height,
            96, 96, PixelFormats.Pbgra32);
        target.Render(contentControl);
        var encoder = new PngBitmapEncoder();
        var outputFrame = BitmapFrame.Create(target);
        encoder.Frames.Add(outputFrame);
        using (var file = File.OpenWrite("TestImage.png"))
        {
            encoder.Save(file);
        }
    }
