Public Class MyLoginStatus
    Inherits System.Web.UI.WebControls.LoginStatus
    Public Overrides Sub RenderBeginTag(ByVal writer As System.Web.UI.HtmlTextWriter)
        writer.AddStyleAttribute("display", "none")
        MyBase.RenderBeginTag(writer)
    End Sub
End Class
