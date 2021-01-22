    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) 
        Dim emplTable As DataTable = SiteAccess.DownloadEmployee_H()
        Dim d As String = Format(Date.Now, "d")
        Dim ad() As String = d.Split("/")
        Dim fd As String = ad(0) & ad(1)
        Dim fn As String = "E_" & fd & ".csv"
        Response.ContentType = "text/csv"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & fn)
        CreateCSVFile(emplTable, Response.Output)
        Response.Flush()
        Response.End()
    End Sub
