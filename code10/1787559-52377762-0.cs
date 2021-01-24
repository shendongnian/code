        private string SaveAsEML(ExchangeService service, MailItem mailItem, string savePath)
        {
            using (FileStream fileStream = File.Open(savePath, FileMode.Create, FileAccess.Write))
            {
                PropertySet props = new PropertySet(EmailMessageSchema.MimeContent);
                var email = EmailMessage.Bind(service, mailItem.mail.Id, props);
                fileStream.Write(mailItem.mail.MimeContent.Content, 0, mailItem.mail.MimeContent.Content.Length);
            }
        }
