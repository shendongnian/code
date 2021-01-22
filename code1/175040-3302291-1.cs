    Private Sub copyToClipboard()
    If DataGridView1.CurrentCell IsNot Nothing AndAlso _
        DataGridView1.CurrentCell.Value IsNot Nothing Then
        If DataGridView1.SelectedRows.Count = 1 Then
            My.Computer.Clipboard.SetDataObject(getActiveGrid.GetClipboardContent())
        End If
    End If
    End Sub
    Private Sub pasteFromClipboard()
    Dim oDataObject As IDataObject = My.Computer.Clipboard.GetDataObject
    If oDataObject.GetDataPresent(DataFormats.Text) Then
       Dim strRow as String = Clipboard.GetData(DataFormats.Text)
       
       'Then create a datagridrow using the data       
    End If
    End Sub
