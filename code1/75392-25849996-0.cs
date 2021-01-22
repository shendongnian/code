    System.IO.MemoryStream ms = new System.IO.MemoryStream();
    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 30f, 30f, 30f, 30f);
    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, ms);
    doc.Open();
    doc.Add(new iTextSharp.text.Chunk("hello world"));
    doc.Close();
    byte[] Result = ms.ToArray();
