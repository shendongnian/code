        Protected Sub onLoad()
            Dim recordID As Integer = Request.Querystring("dID")
            Response.Clear()
            Response.ContentType = "text/csv"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & fn)
            CreateCSVFile(emplTable, Response.Output)
            Response.Flush()
            Response.End() 
            lblEmpl.Visible = True
        End Sub
