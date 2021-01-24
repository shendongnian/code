    private static byte[] Compress(byte[] source)
    {
      byte[] compressed;
      using (var memory = new MemoryStream())
      using (var zipped = new ZipOutputStream(memory))
      {
        zipped.IsStreamOwner = false;
        zipped.SetLevel(9);
        var entry = new ZipEntry("data")
        {
          DateTime = DateTime.Now
        };
        zipped.PutNextEntry(entry);
    #if true
        zipped.Write(source, 0, source.Length);
    #else
        using (var src = new MemoryStream(source))
        {
          StreamUtils.Copy(src, zipped, new byte[4096]);
        }
    #endif
        zipped.Close();
        compressed = memory.ToArray();
      }
    #if false
      using (var file = new FileStream("test.zip", FileMode.Create, FileAccess.Write, FileShare.Read))
      {
        file.Write(compressed, 0, compressed.Length);
      }
    #endif
      return compressed;
    }
