    var icon = System.Drawing.Icon.ExtractAssociatedIcon(
        @"C:\Program Files (x86)\JetBrains\dotPeek\v1.1\Bin\dotpeek32.exe");
    var bitmap = icon.ToBitmap();
    byte[] buffer;
    using (var memoryStream = new MemoryStream())
    {
        bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
        buffer = memoryStream.ToArray();
    }
