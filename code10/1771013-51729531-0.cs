    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
    {
    	System.IO.StreamWriter writer = new System.IO.StreamWriter(ms);
    	writer.Write("Some Text");
    	writer.Flush();
    	writer.Dispose();
    	ms.Position = 0;
    
    	System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Plain);
    	System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(ms, ct);
    	attach.ContentDisposition.FileName = "Filename.txt";
    
    	SmtpClient mailClient = new SmtpClient();
    	MailMessage msg = new MailMessage();
    	msg.Attachments.Add(attach);
    	mailClient.Send(msg);
    }
