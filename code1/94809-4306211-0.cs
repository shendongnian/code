Class exTest
    Class myException
        Inherits Exception
        Sub New(ByVal innerException As Exception)
            MyBase.new("Wrapped Exception", innerException)
        End Sub
    End Class
    Shared Function CopyArg1ToArg2AndReturnFalse(Of T)(ByVal arg1 As T, ByRef arg2 As T) As Boolean
        arg2 = arg1
        Return False
    End Function
    Shared Sub testIt()
        Dim theException As Exception = Nothing
        Try
            Try
                Throw New ApplicationException
            Catch ex As Exception When CopyArg1ToArg2AndReturnFalse(ex, theException)
                Throw
            Finally
                If theException IsNot Nothing Then Throw New myException(theException)
            End Try
        Catch ex As myException
            Debug.Print("Exception: " & ex.InnerException.ToString)
        End Try
    End Sub
End Class
