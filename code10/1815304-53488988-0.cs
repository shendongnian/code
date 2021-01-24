    Private Sub SomeDGV_ColumnHeaderMouseClick(sender As Object,
                                                  e As DataGridViewCellMouseEventArgs) Handles dgvPending.ColumnHeaderMouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If My.Computer.Keyboard.CtrlKeyDown Then
                'control key down
            Else
                '
            End If
        End If
    End Sub
