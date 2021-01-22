    Private Sub UserControl1_SizeChanged(ByVal sender As Object, ByVal e As System.Windows.SizeChangedEventArgs) Handles Me.SizeChanged
        If e.HeightChanged Then
            Me.Width = Me.Height
        Else
            Me.Height = Me.Width
        End If
    End Sub
