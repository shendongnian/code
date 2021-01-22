    Private Sub enable_button(ByVal enabled As Boolean)
        If Me.ButtonConnect.InvokeRequired Then
            Dim del As New ButtonInvoke(AddressOf enable_button)
            Me.ButtonConnect.Invoke(del, New Object() {enabled})
        Else
            ButtonConnect.Enabled = enabled
        End If
    End Sub
