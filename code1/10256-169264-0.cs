    Public Class Form1
        Private Sub Form1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
            ScrollTextbox()
        End Sub
        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ScrollTextbox()
        End Sub
        Private Sub ScrollTextbox()
            TextBox1.SelectionStart = TextBox1.TextLength
            TextBox1.ScrollToCaret()
        End Sub
    End Class
