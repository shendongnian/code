    public static Image LoadImage( string fileFullName )
    {
        Stream fileStream = File.OpenRead( fileFullName );
        Image image       = Image.FromStream( fileStream );
    
        // PropertyItems seem to get lost when fileStream is closed to quickly (?); perhaps
        // this is the reason Microsoft didn't want to close it in the first place.
        PropertyItem[] items = image.PropertyItems;
    
        fileStream.Close();
    
        foreach ( PropertyItem item in items )
        {
            image.SetPropertyItem( item );
        }
    
        return image;
    }
