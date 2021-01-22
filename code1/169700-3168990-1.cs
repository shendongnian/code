    Private Function createSmallCopyofExistingTable(ByVal SourceTable As DataTable) As DataTable
        Dim newTable As DataTable = New DataTable()
        'Copy Only 6 columns from the datatable 
        Dim ColumnsToExport() As String = {"ID", "FirstName", "LastName", "DateOfBirth", "City", "State"}
        newTable = SourceTable.DefaultView.ToTable("tempTableName", False, ColumnsToExport)
        Return newTable
    End Function
