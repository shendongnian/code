    Private Function SendQueryToOLE() As DataSet
        Dim rdrDataReader As OleDb.OleDbDataReader
        Dim cmdCommand As OleDb.OleDbCommand
        Dim dtsData As New DataSet
        Dim dtbTable As New DataTable
        Dim i As Integer
        Dim SQLStatement As String
        Dim oleConnection As OleDb.OleDbConnection
            oleConnection.ConnectionString = YourConnectionString
            SQLStatement = "SELECT * FROM Table WHERE Field=1"
            oleConnection.Open()
    
            cmdCommand = New OleDb.OleDbCommand(SQLStatement, moleConnection)
    
            rdrDataReader = cmdCommand.ExecuteReader()
    
            For i = 0 To (rdrDataReader.FieldCount - 1)
                dtbTable.Columns.Add(rdrDataReader.GetName(i), rdrDataReader.GetFieldType(i))
            Next
            dtbTable.BeginLoadData()
    
            Dim values(rdrDataReader.FieldCount - 1) As Object
    
            While rdrDataReader.Read
                rdrDataReader.GetValues(values)
                dtbTable.LoadDataRow(values, True)
            End While
            dtbTable.EndLoadData()
    
            dtsData.Tables.Add(dtbTable)
    
            moleConnection.Close()
    
            Return dtsData
    
    End Function
