    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = &H14 Then
            Return
        End If
        MyBase.WndProc(m)
    End Sub
    Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
        Return
    End Sub
</pre>
