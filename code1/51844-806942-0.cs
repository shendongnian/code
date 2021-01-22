    public class ImageReaderFactory 
    {
        public static ImageReader getImageReader( InputStream is ) 
        {
            int imageType = figureOutImageType( is );
 
            switch( imageType ) 
            {
                case ImageReaderFactory.GIF:
                    return new GifReader( is );
                case ImageReaderFactory.JPEG:
                    return new JpegReader( is );
                // etc.
            }
        }
    }
