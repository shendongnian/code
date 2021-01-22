    Private Sub MyForm_KeyDown(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    
        If e.KeyCode = Keys.Enter Then
            If Me.ActiveControl.Name = Me.TextBox1.Name Then
                ' This is the TextBox we want to be active to run filterByDeviceSN()
                filterByDeviceSN()
            ElseIf Me.ActiveControl.Name = Me.TextBox2.Name Then
                foo()
            End If
        End If
    End Sub
