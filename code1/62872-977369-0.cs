    using (DirectoryEntry mimeMap = new DirectoryEntry("IIS://Localhost/MimeMap"))
    {
        PropertyValueCollection propValues = mimeMap.Properties["MimeMap"];
        foreach(IISOle.MimeMapClass mimeType in propValues)
        {
          //access mimeType.MimeType to get the mime type string.
        }
    }
