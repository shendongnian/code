    'Ends Edit Mode So CellValueChanged Event Can Fire
    Private Sub EndEditMode(sender As System.Object, e As EventArgs) _
    	Handles DataGridView1.CurrentCellDirtyStateChanged
    	'if current cell of grid is dirty, commits edit
    	If DataGridView1.IsCurrentCellDirty Then
    		DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
    	End If
    End Sub
