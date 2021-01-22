Imports System.Net.Mail
Public Class SSLMail
    Public Shared Sub SendMail(ByVal e As System.Web.UI.WebControls.MailMessageEventArgs)
        GetSmtpClient.Send(e.Message)
        'Since the message is sent here, set cancel=true so the original SmtpClient will not try to send the message too:
        e.Cancel = True
    End Sub
    Public Shared Sub SendMail(ByVal Msg As MailMessage)
        GetSmtpClient.Send(Msg)
    End Sub
    Public Shared Function GetSmtpClient() As SmtpClient
        Dim smtp As New Net.Mail.SmtpClient
        'Read EnableSSL setting from web.config
        smtp.EnableSsl = CBool(ConfigurationManager.AppSettings("EnableSSLOnMail"))
        Return smtp
    End Function
End Class
