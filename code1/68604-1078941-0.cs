    MigraDoc.DocumentObjectModel.Document doc = new MigraDoc.DocumentObjectModel.Document();
    MigraDoc.Rendering.DocumentRenderer renderer = new DocumentRenderer(doc);
    MigraDoc.Rendering.PdfDocumentRenderer pdfRenderer = new MigraDoc.Rendering.PdfDocumentRenderer();
    pdfRenderer.PdfDocument = pDoc;
    pdfRenderer.DocumentRenderer = renderer;
    using (MemoryStream ms = new MemoryStream())
    {
      pdfRenderer.Save(ms, false);
      byte[] buffer = new byte[ms.Length];
      ms.Seek(0, SeekOrigin.Begin);
      ms.Flush();
      ms.Read(buffer, 0, (int)ms.Length);
    }
