    Imports WindowsHookLib
    Public Class frmMain
    
        Dim WithEvents gkh As New LLKeyboardHook
    
        Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            gkh.RemoveHook()
            ghk.Dispose()
        End Sub
    
        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            gkh.InstallHook()
        End Sub
    
    
        Private Sub gkh_KeyDown(ByVal sender As Object, ByVal e As WindowsHookLib.KeyEventArgs) Handles gkh.KeyDown
            If e.KeyCode = Keys.G Then
                REM G is pressed!                
            End If
        End Sub
        Private Sub gkh_KeyUp(ByVal sender As Object, ByVal e As WindowsHookLib.KeyEventArgs) Handles gkh.KeyUp
            If e.KeyCode = Keys.G Then
                REM G was pressed and now released
            End If
        End Sub
        
    End Class
