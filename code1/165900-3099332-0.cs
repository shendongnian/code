    public Stream GetDownloadFile(...)
    {
      using (var stream = new MemoryStream()) {
        return stream;
      }
    }
    
    public Stream GetDownloadFile(...)
    {
      using (var generator = DocumentGenerator.OpenTemplate(path))
      {
        // Document manipulation.
        
        return File(generator.GetDocumentStream(), "text/plain", filename);
      }
    }
