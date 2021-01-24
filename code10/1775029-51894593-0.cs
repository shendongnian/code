    string f = @"C:\yourfolder\yourfile.png";
    using (var binaryReader = new System.IO.BinaryReader(objFile.InputStream))
    {
        byte[] fileData = binaryReader.ReadBytes(objFile.ContentLength);
        using (System.IO.FileStream FileStream1 =
             new System.IO.FileStream(f, System.IO.FileMode.Create,
                                      System.IO.FileAccess.Write))
        {
            FileStream1.Write(fileData, 0, fileData.Length);
            FileStream1.Close();
        }
    }  
    
    return "http://yourdomain.com/yourfolder/yourfile.png"; //modify this to your return type
