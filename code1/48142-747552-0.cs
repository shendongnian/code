    FileStream inFile;
    byte[] binaryData;
    string strFileName;
    
    strFileName = @"C:\MyPicture.jpeg";
    
    inFile = new System.IO.FileStream(strFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
    binaryData = new byte[inFile.Length];
    int bytesRead = inFile.Read(binaryData, 0, binaryData.Length);
    inFile.Close();
