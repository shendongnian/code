    MailMessage Message = new MailMessage();
    
    Message.Subject = "Attachment Test";
    Message.Body = "Check out the attachment!";
    Message.To.Add("webmaster@15Seconds.com");
    Message.From = "someone@somedomain.com";
    
    Message.Attachments.Add(new Attachment(memorystream, "test.txt", MediaTypeNames.Application.Text));
