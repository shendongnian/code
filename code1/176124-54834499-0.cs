    Private Sub dgvs_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgv.DataError
        Dim dgv As DataGridView
        Dim percentageClearedValue As Double
        dgv = CType(sender, DataGridView)
        If e.Exception IsNot Nothing Then
            percentageClearedValue = ConvPercentToDbl(dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue)
            If percentageClearedValue <> Double.MinValue Then
                dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = percentageClearedValue
                dgv.UpdateCellValue(e.ColumnIndex, e.RowIndex)
                dgv.EndEdit()
                e.ThrowException = False
            End If
        End If
    End Sub
