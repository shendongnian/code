    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If Form2.IsHandleCreated = True Then
            Form2.Close()
        End If
    End Sub
