    Private Sub CellContentClick(ByVal sender As DataGridView, ByVal e As DataGridViewCellEventArgs) _
            Handles DataGridView1.CellContentClick
        Try
            'make sure click not on header and also event arg column index is of type ButtonColumn
            If e.RowIndex >= 0 AndAlso sender.Columns(e.ColumnIndex).GetType() = GetType(DataGridViewButtonColumn) Then
                'TODO - Execute Code Here
            End If
        Catch ex As Exception
            HandleErrors(ex)
        End Try
    End Sub
