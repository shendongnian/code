        Private Sub MyForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
            Dim eCast As System.Windows.Forms.FormClosingEventArgs
            eCast = TryCast(e, System.Windows.Forms.FormClosingEventArgs)
            If eCast.CloseReason = Windows.Forms.CloseReason.None Then
                MsgBox("Button Pressed")
            Else
                MsgBox("ALT+F4 or [x] or other reason")
            End If
        End Sub
