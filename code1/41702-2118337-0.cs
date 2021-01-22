    byte[] pdf;
    
    using (MemoryStream ms = new MemoryStream()) {
    	Document doc = new Document();
    	PdfWriter.GetInstance(doc, ms);
    	doc.AddTitle("Document Title");
    	doc.Open();
    	doc.Add(new Paragraph("My paragraph."));
    	doc.Close();
    	pdf = ms.GetBuffer();
    }
    
    Response.ContentType = "application/pdf";
    Response.AddHeader("Content-Disposition", "attachment;filename=MyDocument.pdf");
    Response.OutputStream.Write(pdf, 0, pdf.Length);
