    Private Sub Application_DispatcherUnhandledException(ByVal sender As Object, ByVal e As System.Windows.Threading.DispatcherUnhandledExceptionEventArgs) Handles Me.DispatcherUnhandledException
        'TODO: Log error'
        Dim sb As New System.Text.StringBuilder(e.Exception.Message & vbCrLf)
        Dim ex = e.Exception.InnerException
        While ex IsNot Nothing
            sb.AppendLine("______________ inner exception: ______________")
            sb.AppendLine(ex.Message)
            sb.AppendLine(vbCrLf)
            ex = ex.InnerException
        End While
        If MessageBox.Show(sb.ToString, "Exception caught", MessageBoxButton.OKCancel) = MessageBoxResult.Cancel Then Stop
        e.Handled = True
    End Sub
