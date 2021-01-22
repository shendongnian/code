    public static Image ResizePicture( Image image, Size maxSize )
    {
      if( image == null )
        throw new ArgumentNullException( "image", "Null passed to ResizePictureToMaximum" );
      if( ( image.Width > maxSize.Width ) || ( image.Height > maxSize.Height ) )
      {
        Image resizedImage = new Bitmap( maxSize.Width, maxSize.Height );
        using( Graphics graphics = Graphics.FromImage( resizedImage ) )
        {
          graphics.Clear( Color.White );
          float widthRatio = maxSize.Width / image.Width;
          float heightRatio = maxSize.Height / image.Height;
          int width = maxSize.Width;
          int height = maxSize.Height;
          if( widthRatio > heightRatio )
          {
            width = ( int )Math.Ceiling( maxSize.Width * heightRatio );
          }
          else if( heightRatio > widthRatio )
          {
            height = ( int )Math.Ceiling( maxSize.Height * widthRatio );
          }
          graphics.DrawImage(
            image,
            new Rectangle( 0, 0, width, height ),
            new Rectangle( 0, 0, image.Width, image.Height ),
            GraphicsUnit.Pixel );
        }
        return resizedImage;
      }
      return image;
    }
