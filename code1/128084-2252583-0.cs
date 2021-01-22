    Public Sub exportTableExcel(ByVal aTable, ByVal filename)
        Dim sw As New StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        HttpContext.Current.Response.ClearContent()
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & filename)
        HttpContext.Current.Response.ContentType = "application/vnd.xls"
        HttpContext.Current.Response.Charset = ""
        ' Create a form to contain the table 
        Dim frm As New HtmlForm()
        aTable.Parent.Controls.Add(frm)
        frm.Attributes("runat") = "server"
        'prevent additional code from being exported
        frm.attributes("maintainScrollPositionOnPostBack") = "false"
        frm.Controls.Add(aTable)
        frm.RenderControl(htw)
        HttpContext.Current.Response.Write(sw.ToString())
        HttpContext.Current.Response.End()
        frm.Dispose()
        htw.Dispose()
        sw.Dispose()
    End Sub
