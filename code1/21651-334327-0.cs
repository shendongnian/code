    Private Sub dgv_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv.CellFormatting
        If e.RowIndex < 0 Then Exit Sub
        If e.RowIndex Mod 2 = 0 Then
            e.CellStyle.BackColor = Color.Orange
        Else
            e.CellStyle.BackColor = Color.Red
        End If
        'Make the selected cell the same color
        e.CellStyle.SelectionBackColor = e.CellStyle.BackColor
        e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor
    End Sub
