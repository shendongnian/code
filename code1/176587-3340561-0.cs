    BitmapImage GetImage( byte[] rawImageBytes )
    {
        BitmapImage imageSource = null;
    
        try
        {
            using ( MemoryStream stream = new MemoryStream( rawImageBytes  ) )
            {
                stream.Seek( 0, SeekOrigin.Begin );
                BitmapImage b = new BitmapImage();
                b.SetSource( stream );
                imageSource = b;
            }
        }
        catch ( System.Exception ex )
        {
        }
    
        return imageSource;
    }
