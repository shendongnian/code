    public static string SendEmail(string To, string Subject, string Msg, bool bodyHtml = false, bool test = false, Stream AttachmentStream = null, string AttachmentType = null, string AttachmentFileName = null)
    {
        try
        {
            System.Net.Mail.MailMessage newMsg = new System.Net.Mail.MailMessage(System.Configuration.ConfigurationManager.AppSettings["mailCfg"], To, Subject, Msg);
            newMsg.BodyEncoding = System.Text.Encoding.UTF8;
            newMsg.HeadersEncoding = System.Text.Encoding.UTF8;
            newMsg.SubjectEncoding = System.Text.Encoding.UTF8;
    
            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
            if (AttachmentStream != null && AttachmentType != null && AttachmentFileName != null)
            {
                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(AttachmentStream, AttachmentFileName);
                System.Net.Mime.ContentDisposition disposition = attachment.ContentDisposition;
                disposition.FileName = AttachmentFileName;
                disposition.DispositionType = System.Net.Mime.DispositionTypeNames.Attachment;
    
                newMsg.Attachments.Add(attachment);
            }
            if (test)
            {
                smtpClient.PickupDirectoryLocation = "C:\\TestEmail";
                smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.SpecifiedPickupDirectory;
            }
            else
            {
                //smtpClient.EnableSsl = true;
            }
    
            newMsg.IsBodyHtml = bodyHtml;
            smtpClient.Send(newMsg);
            return SENT_OK;
        }
        catch (Exception ex)
        {
    
            return "Error: " + ex.Message
                 + "<br/><br/>Inner Exception: "
                 + ex.InnerException;
        }
    
    }
