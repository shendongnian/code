    Private exportToExcel As Boolean = False
    Private Sub LoadInExcel()
        Me.Response.ClearContent()
        Me.Response.AddHeader("content-disposition", "attachment; filename=MyFile.xls")
        Me.Response.ContentType = "application/ms-excel"
        Dim sw1 As New IO.StringWriter
        Dim htw1 As HtmlTextWriter = New HtmlTextWriter(sw1)
        GridView1.RenderControl(htw1)
        Response.Write(sw1.ToString())
        Response.End()
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Confirms that an HtmlForm control is rendered for the specified ASP.NET
        ' server control at run time.
    End Sub
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        If exportToExcel Then
            LoadInExcel()
        End If
        MyBase.Render(writer)
    End Sub
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        exportToExcel = True
    End Sub
