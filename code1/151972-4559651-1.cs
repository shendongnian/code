    Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)delegate()
    {
        //serialize image on UI thread
        imageStream = GetImageBytes(cameraImage);
    }
    ...
    //reconstruct image on a different thread:
    Bitmap bitmap = new Bitmap(imageStream); 
    private MemoryStream GetImageBytes(BitmapSource image)
    {
        MemoryStream ms = new MemoryStream();
        BitmapEncoder encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(image));
        encoder.Save(ms);
        ms.Seek(0, SeekOrigin.Begin);
        return ms;
    }
