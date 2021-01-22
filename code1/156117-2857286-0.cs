    var filePath = "C:\\path\\to\\file.txt";
    var smtpClient = new SmtpClient("mailhost");
    using (var message = new MailMessage())
    {
        message.To.Add("to@domain.com");
        message.From = new MailAddress("from@domain.com");
        message.Subject = "Test";
        message.SubjectEncoding = Encoding.UTF8;
        message.Body = "Test " + DateTime.Now;
        message.Attachments.Add(new Attachment(filePath));
    }
    if (File.Exists(filePath)) File.Delete(filePath);
    Console.WriteLine(File.Exists(filePath));
