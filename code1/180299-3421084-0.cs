    var tempFile = System.IO.Path.GetTempFileName();
    System.IO.File.Copy(@"C:\Test.mdb", tempFile, true);
    // 2. Test tempFile
    // 3. Release handles to tempFile, use a using statement around any 
    //    streams or System.IO API's that are using the file in any way.
    System.IO.File.Delete(tempFile);
    
