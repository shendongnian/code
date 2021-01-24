    Imports Gma.System.MouseKeyHook
    Public Class Form1
        Dim m_GlobalHook As IKeyboardMouseEvents
        Private Sub Subscribe()
            m_GlobalHook = Hook.GlobalEvents()
            AddHandler m_GlobalHook.MouseClick, AddressOf m_GlobalHook_MouseClick
        End Sub
        Private Sub m_GlobalHook_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
        
        End Sub
        Public Sub Unsubscribe()
            RemoveHandler m_GlobalHook.MouseClick, AddressOf m_GlobalHook_MouseClick
            m_GlobalHook.Dispose()
        End Sub
    End Class
