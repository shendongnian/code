    public static BitmapImage ByteArraytoBitmap(Byte[] byteArray)
        {
            MemoryStream stream = new MemoryStream(byteArray);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.SetSource(stream);
            return bitmapImage;
        }
