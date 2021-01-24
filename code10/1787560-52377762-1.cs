         private string SaveAsEML(ExchangeService service, MailItem mailItem, string savePath)
        {
            using (FileStream fileStream = File.Open(savePath, FileMode.Create, FileAccess.Write))
            {
                PropertySet props = new PropertySet(EmailMessageSchema.MimeContent);
                var email = EmailMessage.Bind(service, mailItem.mail.Id, props);
                fileStream.Write(email.MimeContent.Content, 0, email .MimeContent.Content.Length);
            }
        }
