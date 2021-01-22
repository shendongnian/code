    Private Sub CellContentClick(ByVal sender As DataGridView, ByVal e As DataGridViewCellEventArgs) _
            Handles DataGridView1.CellContentClick
            'make sure click not on header and also event arg column index is of type ButtonColumn
            If e.RowIndex >= 0 AndAlso sender.Columns(e.ColumnIndex).GetType() = GetType(DataGridViewButtonColumn) Then
                'TODO - Execute Code Here
            End If
    End Sub
