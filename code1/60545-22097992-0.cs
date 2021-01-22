    Private Sub DataGridView_CellBeginEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridViewMsg.CellBeginEdit
        If DataGridViewMsg.Rows(e.RowIndex).Cells("disable").Value = "Y" Then
            e.Cancel = True
        End If
    End Sub
