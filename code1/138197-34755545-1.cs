    Public Sub AddGlobalHotkeySupport()  'TODO: call this at initialization of the application
        ' register the event that is fired after the key press.
        AddHandler hook.KeyPressed, AddressOf hook_KeyPressed
        ' register the control + alt + F12 combination as hot key.
        hook.RegisterHotKey(Application1.ModifierKeys.Control Or Application1.ModifierKeys.Alt, Keys.F12)
    End Sub
    Public Sub RemoveGlobalHotkeySupport()  'TODO: call this at finalization of the application
        ' unregister all registered hot keys.
        hook.Dispose()
    End Sub
    Private Sub hook_KeyPressed(sender As Object, e As KeyPressedEventArgs)
        ' show the keys pressed in a label.
        MsgBox(e.Modifier.ToString() + " + " + e.Key.ToString())
    End Sub
