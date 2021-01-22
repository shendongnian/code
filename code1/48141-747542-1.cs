    string FileName = @"C:\MyPicture.jpeg";
    byte[] binaryData;
    long bytesRead;
    using (var inFile = new System.IO.FileStream(FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read) )
    {
        binaryData = new byte[inFile.Length];
        bytesRead = inFile.Read(binaryData, 0, (int)inFile.Length);
    }
    //I'm assuming you're actually doing something with each byte array here
