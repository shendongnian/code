    Imports System.Runtime.InteropServices
    
    Public Class xxxxxxxxxxxxxxxxxxxxxx
    
    <DllImport("user32.dll")>
        Private Shared Function HideCaret(ByVal hwnd As IntPtr) As Boolean
        End Function
    
    ...............
    
    Private Sub txtNotePreview_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotePreview.MouseMove, txtNotePreview.KeyPress
            HideCaret(txtNotePreview.Handle)
        End Sub
