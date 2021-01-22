    Private Sub dtpDateTimePicker_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Delta > 0 Then
            SendKeys.Send("{Up}")
        Else
            SendKeys.Send("{Down}")
        End If
    End Sub
     
