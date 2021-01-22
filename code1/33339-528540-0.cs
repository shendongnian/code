    Dim savedCursor As Windows.Forms.Cursor
    Private Sub ToolStripButton1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton1.MouseEnter
        If savedCursor Is Nothing Then
            savedCursor = Me.Cursor
            Me.Cursor = Cursors.UpArrow
        End If
    End Sub
    Private Sub ToolStripButton1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton1.MouseLeave
        Me.Cursor = savedCursor
        savedCursor = Nothing
    End Sub
