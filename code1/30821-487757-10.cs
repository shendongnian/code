    Public Module Extensions
        <DllImport("user32.dll")>
        Private Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Boolean, ByVal lParam As IntPtr) As Integer
        End Function
        Private Const WM_SETREDRAW As Integer = 11
        ' Extension methods for Control
        <Extension()>
        Public Sub ResumeDrawing(ByVal Target As Control, ByVal Redraw As Boolean)
            SendMessage(Target.Handle, WM_SETREDRAW, True, 0)
            If Redraw Then
                Target.Refresh()
            End If
        End Sub
        <Extension()>
        Public Sub SuspendDrawing(ByVal Target As Control)
            SendMessage(Target.Handle, WM_SETREDRAW, False, 0)
        End Sub
        <Extension()>
        Public Sub ResumeDrawing(ByVal Target As Control)
            ResumeDrawing(Target, True)
        End Sub
    End Module
