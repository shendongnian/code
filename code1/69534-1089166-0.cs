    public static string Compress(string text)
    {
     byte[] buffer = Encoding.UTF8.GetBytes(text);
     MemoryStream ms = new MemoryStream();
     using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
     {
      zip.Write(buffer, 0, buffer.Length);
     }
    
     ms.Position = 0;
     MemoryStream outStream = new MemoryStream();
    
     byte[] compressed = new byte[ms.Length];
     ms.Read(compressed, 0, compressed.Length);
    
     byte[] gzBuffer = new byte[compressed.Length + 4];
     System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
     System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
     return Convert.ToBase64String (gzBuffer);
    }
