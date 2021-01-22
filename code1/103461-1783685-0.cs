    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
            Select Case e.KeyCode
                Case Keys.Enter
                    ComboBox2.Focus()
            End Select
        End Sub
