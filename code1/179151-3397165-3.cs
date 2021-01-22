    Private Sub PrintColumnNames(dataSet As DataSet)
        Dim table As DataTable
        Dim column As DataColumn 
    
        For Each table in dataSet.Tables
            For Each column in table.Columns
            Console.WriteLine(column.ColumnName)
            Next
        Next
    End Sub
