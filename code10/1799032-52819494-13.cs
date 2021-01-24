    Public Function InitializeSqlCommand(cn As SqlConnection, query As String, ParamArray paramters() As SqlParamter) As SqlCommand
        Dim result As SqlCommand = cn.CreateCommand()
        result.CommandText = query
        If parameters IsNot Nothing AndAlso parameter.Length > 0 Then
           result.Parameters.AddRange(parameters)
        End If
        Return result
    End Sub
