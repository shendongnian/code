    using (DirectoryEntry directory = new DirectoryEntry("IIS://Localhost/MimeMap")) {
        PropertyValueCollection mimeMap = directory.Properties["MimeMap"];
        foreach (object Value in mimeMap) {
            IISOle.MimeMap mimetype = (IISOle.MimeMap)Value;
            //use mimetype.Extension and mimetype.MimeType to determine 
            //if it matches the type you are looking for
        }
     }
