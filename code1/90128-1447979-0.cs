    Public Function Nz(ByVal value As String, ByVal valueIfNothing As String) As String
        Try
            Dim sValue As String = System.Convert.ToString(value) 'using Convert.ToString on purpose
            If IsNothing(sValue) Then
                Return valueIfNothing 
            Else
                Return sValue
            End If
        Catch ex As Exception
            'Convert.ToString handles exceptions, but just in case...
            Debug.Fail("Nz() failed. Convert.ToString threw exception.")
            Return String.Empty
        End Try
    End Function
