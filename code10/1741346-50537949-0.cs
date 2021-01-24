    private async Task Foo(CancellationToken cancel)
    {
        using (var bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
        using (var graphics = Graphics.FromImage(bitmap))
        {
            while (true)
            {
                cancel.ThrowIfCancellationRequested();
                graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
                ProcessImage(bitmap);
                await Task.Delay(200);
            }
        }
    }
