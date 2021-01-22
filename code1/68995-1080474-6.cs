    var file = new FileStream("c:\\foo.txt", FileMode.Open);
    var mem = new MemoryStream();
    // If using .NET 4 or later:
    file.CopyTo(mem);
    // Otherwise:
    CopyStream(file, mem);
    // getting the internal buffer (no additional copying)
    byte[] buffer = mem.GetBuffer();
    long length = mem.Length; // the actual length of the data 
                              // (the array may be longer)
    // if you need the array to be exactly as long as the data
    byte[] truncated = mem.ToArray(); // makes another copy
