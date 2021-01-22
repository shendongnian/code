      Private Sub ÜberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÜberToolStripMenuItem.Click
            
            'About.StartPosition = FormStartPosition.Manual ' !!!!!
            About.Location = New Point(Me.Location.X + Me.Width / 2 - About.Width / 2, Me.Location.Y + Me.Height / 2 - About.Height / 2)
            About.Show()
        End Sub
