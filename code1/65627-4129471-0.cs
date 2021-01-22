        Private Sub DateTimePickerAlarm_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DateTimePickerAlarm.MouseWheel
            If e.Delta > 0 Then
                Native.User32.SendMessage(DateTimePickerAlarm.Handle, &H100, Keys.Up, &H1480001)
                Native.User32.SendMessage(DateTimePickerAlarm.Handle, &H101, Keys.Up, &HC1480001)
            Else
                Native.User32.SendMessage(DateTimePickerAlarm.Handle, &H100, Keys.Down, &H1500001)
                Native.User32.SendMessage(DateTimePickerAlarm.Handle, &H101, Keys.Down, &HC1500001)
            End If
            'msg=0x100 (WM_KEYDOWN) hwnd=0x???????? wparam=0x26 lparam=0x01480001 result=0x0
            'msg=0x101 (WM_KEYUP)   hwnd=0x???????? wparam=0x26 lparam=0xc1480001 result=0x0
            'msg=0x100 (WM_KEYDOWN) hwnd=0x???????? wparam=0x28 lparam=0x01500001 result=0x0
            'msg=0x101 (WM_KEYUP)   hwnd=0x???????? wparam=0x28 lparam=0xc1500001 result=0x0
        End Sub
