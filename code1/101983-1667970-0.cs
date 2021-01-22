    #If Not Debug Then
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf Me.Application_UnhandledException
            AddHandler Application.ThreadException, AddressOf Me.Application_ThreadException
    #End If
----------
    Private Sub Application_UnhandledException(ByVal sender As Object, ByVal e As System.UnhandledExceptionEventArgs)
        Me.UnhandledExceptionLog(TryCast(e.ExceptionObject, Exception).Message, New StackTrace(TryCast(e.ExceptionObject, Exception), True), e.ExceptionObject)
    End Sub
    Private Sub Application_ThreadException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
        Me.UnhandledExceptionLog(e.Exception.Source & Environment.NewLine & e.Exception.Message & Environment.NewLine & e.Exception.StackTrace, New StackTrace(e.Exception, True), e.Exception)
    End Sub
    Public Sub UnhandledExceptionLog(ByVal message As String, ByVal stack As StackTrace, ByVal ex As Object)
        ' write the exception details to a log and inform the user the he screwed something ;) '
    End Sub
