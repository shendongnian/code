    string originalImgPath = @"C:\test.gif";
    Image IMG = Image.FromFile(originalImgPath);
    FrameDimension dimension = new FrameDimension(IMG.FrameDimensionsList[0]);
    int frameCount = IMG.GetFrameCount(dimension);
    int Length = frameCount;
    GifBitmapEncoder gEnc = new GifBitmapEncoder();
    for (int i = 0; i < Length; i++)
    {
        // Get each frame
        IMG.SelectActiveFrame(dimension, i);
        var aFrame = new Bitmap(IMG);
        
        // write one the selected frame
        Graphics graphics = Graphics.FromImage(aFrame);
        graphics.DrawString("Hello", new Font("Arial", 24, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, 50, 50);
        var bmp = aFrame.GetHbitmap();
        var src = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    bmp,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
        // merge frames
        gEnc.Frames.Add(BitmapFrame.Create(src));
    }
    string saveImgFile = @"C:\modified_test.gif"
    using (FileStream fs2 = new FileStream(saveImgFile, FileMode.Create))
    {
        gEnc.Save(fs2);
    }
