    Public Class UserControl1
    Inherits System.Windows.Forms.RichTextBox
    Public Event UserScroll()
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = &H115 Then
            RaiseEvent UserScroll()
        End If
        MyBase.WndProc(m)
    End Sub
    End Class
