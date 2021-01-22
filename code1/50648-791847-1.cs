    byte[] xmlByteArray;
    using (MemoryStream memoryStream = new MemoryStream())
    {
        xmlDocument.Save(memoryStream);
        xmlBytes = memoryStream.ToArray();
    }
    
    string destinationUrl = “http://webserver/site/Doclib/UploadedDocument.xml”
    string[] destinationUrlArray = new string[] { destinationUrl };
    
    FieldInformation fieldInfo = new FieldInformation();
    FieldInformation[] fields = { fieldInfo };
    
    
    CopyResult[] resultsArray;
    
    using (Copy copyService = new Copy())
    {
        copyService.Credentials = CredentialCache.DefaultCredentials;
        copyService.Url = "http://webserver/site/_vti_bin/copy.asmx";
    
        copyService.Timeout = 600000;
    
        uint documentId = copyService.CopyIntoItems(destinationUrl , destinationUrlArray, fields, xmlByteArray, out resultsArray);
    }
