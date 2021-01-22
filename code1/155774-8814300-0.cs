    ' code in vb.net you can convert it to c# easily
    Dim ConnectionString As String = "your connection string"
    Public Function KillAllMySQL() As Integer
        Dim query As String = "SHOW FULL PROCESSLIST"
        '
        Try
            Dim mySqlConnection As MySqlConnection = New MySqlConnection(ConnectionString)
            ' 2. open connection to database using connectionString
            mySqlConnection.Open()
            ' 3. Create a command to hold values
            Dim objCmd As New MySqlCommand(query, mySqlConnection)
            ' 4. Add parameters for sqlCommand
            mySqlDataReader = objCmd.ExecuteReader()
            If mySqlDataReader.HasRows Then
                Do While mySqlDataReader.Read()
                    ' kill processes with elapsed time > 200 seconds and in Sleep 
                    If mySqlDataReader.GetInt32(5) > 200 And mySqlDataReader.GetString(4) = "Sleep" Then
                        KillMySqlProcess("KILL " & mySqlDataReader.GetInt32(0))
                    End If
                Loop
            End If
            If Not mySqlDataReader Is Nothing Then mySqlDataReader.Close()
            If Not mySqlConnection Is Nothing Then mySqlConnection.Close()
        Catch ex As MySqlException
            Return -1
        End Try
        Return 0
    End Function
    Public Function KillMySqlProcess(ByVal myQuery As String) As Integer
        '1. Create a query
        Dim query As String = myQuery
        '
        Try
            Dim mySqlConnection As MySqlConnection = New MySqlConnection(ConnectionString)
            ' 2. open connection to database using connectionString
            mySqlConnection.Open()
            ' 3. Create a command to hold values
            Dim objCmd As New MySqlCommand(query, mySqlConnection)
            objCmd.ExecuteNonQuery()
            mySqlConnection.Close()
        Catch ex As MySqlException
            Return -1
        End Try
        Return 0
    End Function
