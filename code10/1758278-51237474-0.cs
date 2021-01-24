    using System.IO;
    using System.Windows.Media.Imaging;
    int CurrentFrame = 0;
    string SourceFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "myGif.gif");
    string FramesDestinationPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "myGif-Frames");
    
    using (FileStream SourceStream = new FileStream(SourceFile, FileMode.Open, FileAccess.Read, FileShare.None))
    {
        var bitmapDecoder = BitmapDecoder.Create(SourceStream,
                            BitmapCreateOptions.PreservePixelFormat,
                            BitmapCacheOption.Default);
        foreach (BitmapFrame frame in bitmapDecoder.Frames)
        {
            ++CurrentFrame;
            using (FileStream PngStream = new FileStream(FramesDestinationPath + $@"\frame{CurrentFrame}.png", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PngBitmapEncoder PngEncoder = new PngBitmapEncoder();
                PngEncoder.Frames.Add(frame);
                PngEncoder.Save(PngStream);
            }
        }
    }
