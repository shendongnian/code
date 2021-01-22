    Dim oleConn As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & myDB & ";User Id=admin;Password=;")
    
    oleConn.Open()
    Dim schemaTable As DataTable
    Dim i As Integer
    schemaTable = oleConn.GetOleDbSchemaTable(OleDbSchemaGuid.Column s, _
    New Object() {Nothing, Nothing, "tblTheTableToListColumns", Nothing})
    For i = 0 To schemaTable.Columns.Count - 1
    Debug.Print(schemaTable.Rows(i)!COLUMN_NAME.ToStri ng)
    Next i
    oleConn.Close()
