    using System.Net;
    using System.Net.Mime;
    using System.Net.Mail;
    
    ...
    ...
    
    public static void CreateMessageWithAttachment(string server)
    {
        // Specify the file to be attached and sent
        string file = @"C:\Temp\data.xls";
    
        // Create a message and set up the recipients.
        MailMessage message = new MailMessage(
               "from@gmail.com",
               "to@gmail.com",
               "Subject: Email message with attachment.",
               "Body: See the attached spreadsheet.");
    
        // Create the file attachment for this e-mail message.
        Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
    
        // Add time stamp information for the file.
        ContentDisposition disposition = data.ContentDisposition;
        disposition.CreationDate = System.IO.File.GetCreationTime(file);
        disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
        disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
    
        // Add the file attachment...
        message.Attachments.Add(data);
    
        SmtpClient client = new SmtpClient(server);
    
        // Add credentials if the SMTP server requires them.
        client.Credentials = CredentialCache.DefaultNetworkCredentials;
    
        try
        {
            client.Send(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("CreateMessageWithAttachment() Exception: {0}",
                  ex.ToString());
            throw;
        }
    
    }
