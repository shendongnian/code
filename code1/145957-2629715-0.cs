    stringAsStream = new MemoryStream();
    
    // create stream writer with UTF-16 (Unicode) encoding to write to the memory stream
    using(StreamWriter sWriter = new StreamWriter(stringAsStream, UnicodeEncoding.Unicode))
    {
      sWriter.Write("Lorem ipsum.");
    }
    stringAsStream.Position = 0L; // rewind
