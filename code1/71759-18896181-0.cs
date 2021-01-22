    Private Sub Form1_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        Me.Focus()
        Me.Enabled = True
        Form2.Enabled = False
    End Sub
    Private Sub Form1_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        Form2.Enabled = True
        Form2.Focus()
    End Sub
