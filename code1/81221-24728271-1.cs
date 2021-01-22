    ' Great tip. So if it helps to VisualBasic In Code
    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const SC_MAXIMIZE As Integer = &HF030
    ' # WndProcess 루프함수
    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg.Equals(WM_SYSCOMMAND) Then
            If (m.WParam.ToInt32.Equals(SC_MAXIMIZE)) Then
                Me.p_FullScreen()
                Return
            End If
        End If
        MyBase.WndProc(m)
    End Sub
