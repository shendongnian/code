        Private CloseAllowed As Boolean
    
        Protected Overrides Sub OnFormClosing(ByVal e As System.Windows.Forms.FormClosingEventArgs)
            If Not CloseAllowed And e.CloseReason = CloseReason.UserClosing Then
                Me.Hide()
                e.Cancel = True
            End If
            MyBase.OnFormClosing(e)
        End Sub
    
        Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
            CloseAllowed = True
            Me.Close()
        End Sub
