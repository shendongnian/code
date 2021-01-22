    PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
    
    // Build pdf code...
    
    writer.CloseStream = false;
    doc.Close();
    // Build email
    
    memoryStream.Position = 0;
    mm.Attachments.Add(new Attachment(memoryStream, "test.pdf"));
   
