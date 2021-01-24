    void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        try
        {
            System.Drawing.Bitmap img = (Bitmap)eventArgs.Frame.Clone();
            // TODO: add some kind of mutex or similar here so that you don't start a new Decode before the previous one is finished
            Dispatcher.BeginInvoke(new ThreadStart(delegate
            {
                // use the original BarcodeReader because we are using the bitmap instance directly
                BarcodeReader Reader = new ZXing.BarcodeReader();
                Result result = Reader.Decode(img);
                decoded = result?.Text;
                hey.Text = decoded;
            }));
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();
            bi.Freeze();
            Dispatcher.BeginInvoke(new ThreadStart(delegate
            {
                frameHolder.Source = bi;
            }));
        }
        catch (Exception ex)
        {
        }
    }
