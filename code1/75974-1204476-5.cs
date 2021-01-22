    if (dea.Data.GetDataPresent(typeof(BitmapTransfer)))
    {
        BitmapTransfer bitmapTransfer = 
           (BitmapTransfer)dea.Data.GetData(typeof(BitmapTransfer));
        (sender as PictureBox).Image = bitmapTransfer.ToBitmap();
    }
    else if(dea.Data.GetDataPresent(DataFormats.Bitmap))
    {
        Bitmap b = (Bitmap)dea.Data.GetData(DataFormats.Bitmap);
        (sender as PictureBox).Image = b;
    }
