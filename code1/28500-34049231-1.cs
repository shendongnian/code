    Private Sub User_role_groupDataGridView_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles User_role_groupDataGridView.CellBeginEdit
        Try 
            If Not Me.User_role_groupDataGridView.Rows(e.RowIndex).IsNewRow Then Me.User_role_groupDataGridView.Rows(e.RowIndex).Cells("last_modified_user_group_role").Value = Now
        Catch ex As Exception
            Me.displayUserMessage(ex.ToString, Me.Text, True)
        End Try
    End Sub
