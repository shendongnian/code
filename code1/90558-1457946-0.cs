    ...
    mail.Body = txtComments.Text;
    //Attach file
    mail.Attachments.Add(new Attachment(txtAttachments.Text.ToString()));
    mail.Attachments.Add(new Attachment(txtAttachments2.Text.ToString()));
    mail.Attachments.Add(new Attachment(txtAttachments3.Text.ToString()));
    mail.Attachments.Add(new Attachment(txtAttachments4.Text.ToString()));
    SmtpServer.Port = 587;
    ...      
