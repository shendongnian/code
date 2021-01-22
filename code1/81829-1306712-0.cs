    Private Sub mnuCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopy.Click
        If dgvDisplaySet.GetClipboardContent Is Nothing Then
            MsgBox("Nothing selected to copy to clipboard.")
        Else
            Clipboard.SetDataObject(dgvDisplaySet.GetClipboardContent)
        End If
    End Sub
