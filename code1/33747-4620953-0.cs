    Shared Sub TryFaultCatchFinally(Of T)(ByVal TryProc As Action(Of T), _
                                          ByVal FaultProc As Func(Of T, Exception, Boolean), _
                                          ByVal CatchProc As Action(Of T, Exception), _
                                          ByVal FinallyProc As Action(Of T, Exception, Boolean), _
                                          ByVal Value As T)
        Dim theException As Exception = Nothing
        Dim exceptionCaught As Boolean = False
        Try
            TryProc(Value)
            theException = Nothing
            exceptionCaught = False
        Catch Ex As Exception When CopyExceptionAndReturnFalse(Ex, theException) OrElse FaultProc(Value, Ex)
            exceptionCaught = True
            CatchProc(Value, Ex)
        Finally
            FinallyProc(Value, theException, exceptionCaught)
        End Try
    End Sub
