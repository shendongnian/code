    Private Sub CM_Closing(sender As Object, e As ToolStripDropDownClosingEventArgs) Handles CM.Closing
        If e.CloseReason = ToolStripDropDownCloseReason.ItemClicked Then
            Dim ItemClicked As String = CM.GetItemAt(New Point(Cursor.Position.X - CM.Left, Cursor.Position.Y - CM.Top)).Name
            If ItemClicked = "CMHeader" Then
                e.Cancel = True
            End If
        End If
    End Sub
