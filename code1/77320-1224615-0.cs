    System.IO.FileInfo[] files = System.IO.Directory.GetFiles(Server.MapPath("~") + fileName + "*");
    if(files.Length == 1) // We got one and only one file
    {
       using(BinaryReader reader = new BinaryReader(new FileStream(files[0].FullName)))
       {
           // use the stream
       }
    }
    else // 0 or +1 files
    {
     //...
    }
