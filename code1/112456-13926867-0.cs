    ''' <remarks>Intercept the user clicking on the CLOSE button (or ALT+F4'ing) before the closing starts.</remarks>
    Protected Overrides Sub DefWndProc(ByRef m As System.Windows.Forms.Message)
        Try
            Const SC_CLOSE = &HF060 'http://msdn.microsoft.com/en-us/library/ms646360%28v=vs.85%29.aspx
            If (m.Msg = WndMsg.WM_SYSCOMMAND) _
            AndAlso (m.WParam.ToInt32 = SC_CLOSE) Then
                If (Not Me.ExitApplicationPrompt()) Then ' Do your "close child forms" here
                    m.Msg = 0 'Cancel the CLOSE command
                End If
            End If
        Catch ex As Exception
            My.ExceptionHandler.HandleClientError(ex)
        End Try
        MyBase.DefWndProc(m)
    End Sub
