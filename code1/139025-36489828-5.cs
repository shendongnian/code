            using (var mailMessage = new MailMessage("fromaddress@blah.com", "toaddress@blah.com", "subject", "body"))
            {
                //Add an attachment just for the sake of it
                Attachment doc = new Attachment(@"filePath");
                doc.ContentId = "doc";
                mailMessage.Attachments.Add(doc);
                var smtpClient = new SmtpClient("SmtpHost")
                {
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                // Apply credentials
                smtpClient.Credentials = new NetworkCredential("smtpUsername", "smtpPassword");
                // Send
                smtpClient.SendAndSaveMessageToIMAP(mailMessage, "imap.mail.com", 993, "imapUsername", "imapPassword", "SENT");
            }
