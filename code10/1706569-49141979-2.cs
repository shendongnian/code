    #Region "mouseSonar"
    Private Sub mouseHook_Click(sender As Object, e As EventArgs)
        SendKeys.Send("^")
    End Sub
    Private Sub EnableMouseSonar()
        SetMouseSonarEnabled(True)
    End Sub
    Private Sub DisableMouseSonar()
        SetMouseSonarEnabled(False)
    End Sub
    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SystemParametersInfo(ByVal uiAction As UInteger, ByVal uiParam As UInteger, ByVal pvParam As UInteger, ByVal fWinIni As UInteger) As Boolean
    End Function
    Private Sub SetMouseSonarEnabled(ByVal enable As Boolean)
        Const SPI_SETMOUSESONAR As UInteger = 4125
        Const SPIF_UPDATEINIFILE As UInteger = 1
        Const SPIF_SENDCHANGE As UInteger = 2
        If Not SystemParametersInfo(SPI_SETMOUSESONAR, 0, CUInt((If(enable, 1, 0))), SPIF_UPDATEINIFILE Or SPIF_SENDCHANGE) Then
            Throw New Win32Exception()
        End If
    End Sub
    #End Region
