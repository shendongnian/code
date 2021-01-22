    Imports System.Web.UI.HtmlControls
     
    Namespace TestWebApp
     
        Public Class WebForm1
            Inherits System.Web.UI.Page
     
            Protected PageTitle As HtmlGenericControl = New HtmlGenericControl()
     
            Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
     
                PageTitle.InnerText = "New Page Title"
            End Sub
     
    ...
     
        End Class
    End Namespace
