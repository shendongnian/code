    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        BarcodeReader Reader = new ZXing.Presentation.BarcodeReader();
        if (frameHolder.Source != null)
        {
            Result result = Reader.Decode((BitmapSource)frameHolder.Source);
            decoded = result?.Text;
            hey.Text = decoded;
        }
    }
