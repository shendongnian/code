    using (var writer = PdfWriter.GetInstance(doc, fs))
      {
        PdfDictionary info = writer.Info;
        PdfName newData = new PdfName($"NewData");
        info.Put(newData, new PdfString("any string data"));
       }
