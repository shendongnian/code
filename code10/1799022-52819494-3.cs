    Private ReadOnly Property ConnectionString As String
        Get
             Return "connection string here"
        End Get
    End Property
    Public Function CreateSqlConnection() As SqlConnection
        Dim result As New SqlConnection(ConnectionString)
        Return result
    End Function
