    using (DirectoryEntry mimeMap = new DirectoryEntry("IIS://Localhost/MimeMap"))
    {
        PropertyValueCollection propValues = mimeMap.Properties["MimeMap"];
        foreach(IISOle.MimeMap mimeType in propValues) 
        //must cast to the interface and not the class
        {
          //access mimeType.MimeType to get the mime type string.
        }
    }
