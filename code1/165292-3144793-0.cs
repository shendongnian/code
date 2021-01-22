    If Not IsPostBack Then
        Dim ex As Exception = Server.GetLastError().GetBaseException()
        lblExceptionMessage.Text = ex.Message.ToString()
        lblStackTrace.Text = ex.StackTrace().Replace(System.Environment.NewLine, "<br />")
    End If
