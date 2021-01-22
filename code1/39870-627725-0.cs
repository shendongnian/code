    Assembly assembly = Assembly.GetExecutingAssembly();
    using (Stream stream = assembly.GetManifestResourceStream("resource name")
    {
      using FileStream fs= new FileStream("executable name")
      {
        byte[] buffer = new byte[32*1024];
        int bytesRead;
        while ((bytesRead= stream.Read(buffer, 0, buffer.Length)) > 0)
        {
          fs.Write(buffer, 0, bytesRead);
        }
      }
    }
