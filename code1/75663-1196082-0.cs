    var tempFilePath = Path.GetTempFileName();
    
    try 
    {	        
        var doc = new Document();
    
        PdfWriter.GetInstance(doc, File.OpenWrite(tempFilePath));
        doc.Open();
        doc.Add(new Paragraph("First Paragraph"));
        doc.Add(new Paragraph("Second Paragraph"));
    
        doc.Close();
    
        MailMessage mm = new MailMessage("username@gmail.com", "username@gmail.com")
        {
            Subject = "subject",
            IsBodyHtml = true,
            Body = "body"
        };
    
        mm.Attachments.Add(new Attachment(tempFilePath, "test.pdf"));
        SmtpClient smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            Credentials = new NetworkCredential("username@gmail.com", "my_password")
        };
    
        smtp.Send(mm);
    }
    finally
    {
        File.Delete(tempFilePath);
    }
