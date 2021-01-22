    Protected Overrides Sub OnMouseClick(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Me.SelectionStart = 0 Then
            Me.SelectionStart = Me.Text.Length
        End If
    End Sub
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        If Not Me.Text.IndexOf("$") = 0 Then
            Me.Text = "$" + Me.Text.Replace("$", "")
        End If
        If Me.SelectionStart = 0 Then
            Me.SelectionStart = Me.Text.Length
        End If
    End Sub
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If NOT ((Char.IsDigit(e.KeyChar) Or (e.KeyChar = CChar(".") And Not Me.Text.Contains(".")) Or Char.IsControl(e.KeyChar)) And (Not Char.IsDigit(e.KeyChar) Or (Me.SelectionStart <= Me.Text.IndexOf(".") + 2 Or Me.Text.IndexOf(".") = -1))) Then
            e.Handled = True
        End If
    End Sub
