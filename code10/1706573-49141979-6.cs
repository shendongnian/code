    Private Sub m_GlobalHook_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
        EnableMouseSonar()
        SendKeys.Send("^")
        DisableMouseSonar()
    End Sub
