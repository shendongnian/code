    Private Sub Example_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles Me.ControlAdded
        AddHandler e.Control.MouseClick, AddressOf Example_MouseClick
    End Sub
    Private Sub Example_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        MessageBox.Show("Click")
    End Sub
