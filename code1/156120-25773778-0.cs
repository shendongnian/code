        Dim message As New MailMessage
        message.From = New MailAddress(fromEmail, fromName)
        message.Subject = subject
        message.CC.Add(toCCEmail)
        message.Bcc.Add(toBCCEmail)
        Dim attach As Attachment = New Attachment(attachmentPath)
        message.Attachments.Add(attach)
        message.IsBodyHtml = True
        message.Body = body
        mailClient.Send(message)
    
        message.Dispose()   'Add this line to dispose the message!
