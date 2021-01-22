    Imports MailKit.Net.Smtp
    Imports MailKit
    Imports MimeKit
    
    Sub somesub()
        Dim builder As New BodyBuilder()
        Dim mail As MimeMessage
        mail = New MimeMessage()
        mail.From.Add(New MailboxAddress("", c_MailUser))
        mail.To.Add(New MailboxAddress("", c_ToUser))
        mail.Subject = "Mail Subject"
        builder.HtmlBody = "<html><body>Body Text"
        builder.HtmlBody += "</body></html>"
          mail.Body = builder.ToMessageBody()
        
          Using client As New SmtpClient
            client.Connect(c_MailServer, 465, True)
            client.AuthenticationMechanisms.Remove("XOAUTH2") ' Do not use OAUTH2
            client.Authenticate(c_MailUser, c_MailPassword) ' Use a username / password to authenticate.
            client.Send(mail)
            client.Disconnect(True)
        End Using 
    
    End Sub
