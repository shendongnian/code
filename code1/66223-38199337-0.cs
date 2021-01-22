    var imageSourceConverter = new ImageSourceConverter();
    byte[] tempBitmap = BitmapToByte(eventArgs.Frame);
    ImageSource image = (ImageSource)imageSourceConverter.ConvertFrom(tempBitmap);
...
    private byte[] BitmapToByte(Bitmap bitmap)
    {
        byte[] byteArray;
        using (MemoryStream stream = new MemoryStream())
        {
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            stream.Close();
    
            byteArray = stream.ToArray();
        }
        return byteArray;
    }
    
