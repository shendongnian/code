            EmailMessage em = new EmailMessage();
            em.EmailFormat = EmailFormatEnum.Html;
            em.From = "no-reply@foo.com";
            em.Recipients = "foo.bar@baz.net";
            em.Subject = "Attachment Name";
            em.Body = "There is an attachment.";
            using (MemoryStream ms = new MemoryStream())
            {
               var attachment = new EmailAttachment(ms, "foo.pdf");
               em.Attachments.Add(attachment);
            }
            EmailSender.SendEmail(SiteContext.CurrentSiteName, em);
        
