        string filename = Path.GetFileName(imageToSave.FileName);
        string fileExtension = Path.GetExtension(filename);
        int fileSize = imageToSave.ContentLength;
        if (fileExtension.ToLower() == ".jpg" ) /*you could add a check for what type of image you want to be allowed to save*/
        {
            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
         
    SqlParameter paramImageData = new SqlParameter()
    {
    ParameterName = "@ImageData",
    Value = bytes
    };
