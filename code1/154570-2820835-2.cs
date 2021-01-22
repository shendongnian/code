        Protected Sub onLoad()
            Dim recordID As Integer = Request.Querystring("dID")
            Dim emplTable As DataTable = Nothing 
            Select Case recordID 
              case 1: emplTable = SiteAccess.DownloadEmployee_H() 
              case 2: emplTable = SiteAccess.DownloadManagers() 
            End Select 
            Response.Clear()
            Response.ContentType = "text/csv"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & fn)
            CreateCSVFile(emplTable, Response.Output)
            Response.Flush()
            Response.End() 
            lblEmpl.Visible = True
        End Sub
