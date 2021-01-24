    using (var stream = File.OpenRead(testfile.jpg"))
      {
         FormFile file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
           {
             Headers = new HeaderDictionary(),
             ContentType = "image/jpeg"
           };
    }
