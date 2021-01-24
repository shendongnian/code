        Dim csb = New NpgsqlConnectionStringBuilder(GetConnectionString(connectionName))
        csb.CommandTimeout = 0
        Using connection = New NpgsqlConnection(csb.ConnectionString)
            AddHandler connection.StateChange, AddressOf myHandler  ' <== This is where you specify the event Handler
            Using transaction = connection.BeginTransaction()
                ' Do your thing here.
                transaction.Commit()
            End Using
        End Using
    End Sub
    ' This function will get called whenever the connection state changes.
    Private Function myHandler(sender As Object, e As StateChangeEventArgs) As Object
        ' Do something here
    End Function
