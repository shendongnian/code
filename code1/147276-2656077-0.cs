      MemoryStream ms = new MemoryStream();
      using (FileStream fs = File.OpenRead(PathToFile))
      using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress))
      {        
        // This could be replaced with fs.CopyTo(zip); if you are using Framework 4.0
        byte[] buffer = new byte[1024];
        int bytesRead = 0;
        while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
        {        
          zip.Write(buffer, 0, bytesRead);
        }
      }
    
      // Get the compressed bytes from the memmory stream
      byte[] cmpData = ms.ToArray();
