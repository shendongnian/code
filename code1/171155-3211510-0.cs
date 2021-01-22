    Private Sub dgv2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv2.CellClick
        If e.ColumnIndex = -1 Then
           dgv2.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
           dgv2.EndEdit()
        ElseIf dgv2.EditMode <> DataGridViewEditMode.EditOnEnter Then
           dgv2.EditMode = DataGridViewEditMode.EditOnEnter
           dgv2.BeginEdit(False)
        End If
    End Sub
