    protected void btnSendEmail_Click(object sender, EventArgs e)
    {  
        // this will get the file from your asp:FileUpload control (browse button)
        HttpPostedFile file = (HttpPostedFile)(fuAttachment.PostedFile);
        if ((file != null) && (file.ContentLength > 0))
        {
            // You should probably check file size and extension types and whatever
            // other validation here as well
            byte[] uploadedFile = new byte[file.ContentLength];
            file.InputStream.Read(uploadedFile, 0, file.ContentLength);
                   
            // Save the file locally
            int lastSlash = file.FileName.LastIndexOf('\\') + 1;
            string fileName = file.FileName.Substring(lastSlash,
                file.FileName.Length - lastSlash);
            string localSaveLocation = yourLocalPathToSaveFile + fileName;
            System.IO.File.WriteAllBytes(localSaveLocation, uploadedFile);
            try
            {
                // Create and send the email
                MailMessage msg = new MailMessage();
                msg.To = "someone@somewhere.com";
                msg.From = "somebody@somebody.com";
                msg.Subject = "Attachment Test";
                msg.Body = "Test Attachment";
                msg.Attachments.Add(new MailAttachment(localSaveLocation));
                // Don't forget you have to setup your SMTP settings
                SmtpMail.Send(msg);
            }
            finally
            {
                // make sure to clean up the file that was uploaded
                System.IO.File.Delete(localSaveLocation);
            }
        }
    }
