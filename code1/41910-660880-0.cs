       public void AddFileToManipulate(byte[] pdfDocument)
       {
          using (MemoryStream stream = new MemoryStream(pdfDocument))
          {
             pdfDocumentStreams.Add(stream);
          }
       }
