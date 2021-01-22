    public void Bitmap ConvertByteArrayToBitmap(byte[] receivedBytes)
    {
       MemoryStream ms = new MemoryStream(receivedBytes);
       return new Bitmap(ms, System.Drawing.Imaging.ImageFormat.Png); // I recomend you to use png format   
    }
