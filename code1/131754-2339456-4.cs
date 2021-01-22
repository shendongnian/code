            string file = "data.xls";
            // Create a message and set up the recipients.
            MailMessage message = new MailMessage(
               "from@example.com",
               "to@example.com");
            message.Subject = "The subject.";
            message.Body = "See the attached file";
            // Create  the file attachment for this e-mail message.
            Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
            data.ContentId = Guid.NewGuid().ToString();
            // Add time stamp iformation for the file.
            ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(file);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
            // Add the file attachment to this e-mail message.
            message.Attachments.Add(data);
