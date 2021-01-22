    Private Sub Form2_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        Me.Focus()
        Me.Enabled = True
        Form1.Enabled = False
    End Sub
    Private Sub Form2_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        Form1.Enabled = True
        Form1.Focus()
    End Sub
