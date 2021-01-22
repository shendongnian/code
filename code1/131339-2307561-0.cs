    public Picture GetPictureDimension(Stream inputStream, ref Picture picture)
    {
        var img = new MagickNet.Image(inputStream);
    
        picture = new Picture(img);  // just guessing here
        //picture.Width = img.Columns;
        //picture.Height = img.Rows;
    
        return picture;
    }
