	<System.Web.Services.WebMethod()> _
	Public Shared Function GetDetails(ByVal filename As String) As String
		Dim page As Page = New Page()
		Dim ctl As recDetails = CType(page.LoadControl("~/Controles/recDetails.ascx"), recDetails)
		ctl.FileName = filename
		page.EnableEventValidation = False
		Dim _form As New HtmlForm()
		page.Controls.Add(_form)
		_form.Controls.Add(ctl)
		Dim writer As New System.IO.StringWriter()
		HttpContext.Current.Server.Execute(page, writer, False)
		Dim output As String = writer.ToString()
		writer.Close()
		Return output
	End Function
