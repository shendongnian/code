    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hWnd As Integer, _
                                                                    ByVal wMsg As Integer, _
                                                                    ByVal wParam As Integer,
                                                                    ByVal lParam As Integer) As Integer
    Private Const WM_SETREDRAW As Integer = 11
    ' Extension methods for Control
    <Extension()>
    Public Sub ResumeDrawing(ByVal Target As Control, ByVal Redraw As Boolean)
      SendMessage(Target.Handle, WM_SETREDRAW, 1, 0)
      If Redraw Then
        Target.Refresh()
      End If
    End Sub
    <Extension()>
    Public Sub SuspendDrawing(ByVal Target As Control)
      SendMessage(Target.Handle, WM_SETREDRAW, 0, 0)
    End Sub
    <Extension()>
    Public Sub ResumeDrawing(ByVal Target As Control)
      ResumeDrawing(Target, True)
    End Sub
