    Partial Class RecoverPassword
    Inherits System.Web.UI.Page
    Protected Sub RecoverPwd_SendingMail(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MailMessageEventArgs) Handles RecoverPwd.SendingMail
        e.Message.Bcc.Add("webmaster@example.com")
        SSLMail.SendMail(e)
    End Sub
    End Class
