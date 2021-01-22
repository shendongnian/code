    Private Sub copyToClipboard()
    If DataGridView1.CurrentCell IsNot Nothing AndAlso _
        DataGridView1.CurrentCell.Value IsNot Nothing Then
        If DataGridView1.SelectedRows.Count = 1 Then
            My.Computer.Clipboard.SetDataObject(getActiveGrid.GetClipboardContent())
        End If
    End If
