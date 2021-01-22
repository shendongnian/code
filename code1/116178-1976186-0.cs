    try
    {
        SendEmail(SenderEmail, SenderDisplayName, RecipientEmails, Subject, Message);
    }
    catch (MailException ex)
    {
        MessageBox.Show(ex.Message);
    }
