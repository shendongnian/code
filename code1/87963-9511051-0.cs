            Protected Sub ExportToExcel()
            Dim gv1 As GridView = FindControlRecursive(objPlaceHolder, "GridView1")
            If Not gv1 Is Nothing Then
                Response.ClearHeaders()
                Response.ClearContent()
                ' Set the content type to Excel
                Response.ContentType = "application/vnd.ms-excel"
                ' make it open the save as dialog
                Response.AddHeader("content-disposition", "attachment; filename=ExcelExport.xls")
                'Turn off the view state 
                Me.EnableViewState = False
                'Remove the charset from the Content-Type header 
                Response.Charset = String.Empty
                Dim myTextWriter As New System.IO.StringWriter
                Dim myHtmlTextWriter As New System.Web.UI.HtmlTextWriter(myTextWriter)
                Dim frm As HtmlForm = New HtmlForm()
                Controls.Add(frm)
                frm.Controls.Add(gv1)
                'Get the HTML for the control 
                frm.RenderControl(myHtmlTextWriter)
                'Write the HTML to the browser 
                Response.Write(myTextWriter.ToString())
                'End the response 
                Response.End()
            End If
        End Sub
	Private Function FindControlRecursive(ByVal root As Control, ByVal id As String) As Control
		If root.ID = id Then
			Return root
		End If
		Dim c As Control
		For Each c In root.Controls
			Dim t As Control = FindControlRecursive(c, id)
			If Not t Is Nothing Then
				Return t
			End If
		Next
		Return Nothing
	End Function
