     Function RemoveEmptyColumns(Datatable As DataTable) As Boolean
        Dim mynetable As DataTable = Datatable.Copy
        Dim counter As Integer = mynetable.Rows.Count
        Dim col As DataColumn
        For Each col In mynetable.Columns
            Dim dr() As DataRow = mynetable.Select(col.ColumnName + " is   Null ")
            If dr.Length = counter Then
                Datatable.Columns.Remove(col.ColumnName)
                Datatable.AcceptChanges()
            End If
        return true
     end function
