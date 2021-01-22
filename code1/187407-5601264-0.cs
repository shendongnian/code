       Private Sub ListView1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseUp
            If e.Button = MouseButtons.Right And ListView1.SelectedItems.Count > 0 Then
                Dim cn As New ContextMenuStrip()
                cn.Items.Add("Apple")
                Me.ListView1.ContextMenuStrip = cn
                cn.Show(Control.MousePosition.X, Control.MousePosition.Y)
            End If
        End Sub
