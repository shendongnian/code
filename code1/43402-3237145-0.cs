    string fileName = Path.GetTempFileName();
    using (var stream = File.OpenWrite(fileName))
      stream.Write(blobContents);
    // open excel with oledb
    // and do your processing
    using (var stream = File.OpenRead(fileName))
    {
       var buffer = new byte[stream.Length];
       stream.Read(buffer, 0, stream.Length);
       
       //save blob
    }
