    // http://www.flickr.com/services/api/misc.api_keys.html
    string flickrApiKey = "<api key>";
    string flickrApiSharedSecret = "<shared secret>";
    string flickrAuthenticationToken = "<authentication token>";
    
    Flickr flickr = new Flickr( flickrApiKey, flickrApiSharedSecret );
    
    flickr.AuthToken = flickrAuthenticationToken;    
    
    foreach ( FileInfo image in new FileInfo[] { 
        new FileInfo( @"C:\image1.jpg" ), 
        new FileInfo( @"C:\image2.jpg" ) } )
    {
        string photoId = flickr.UploadPicture(
            image.FullName, image.Name, image.Name, "tag1, tag2" );
    }
