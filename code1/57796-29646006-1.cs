    Public Class Utils
    	<System.Runtime.InteropServices.DllImport("user32.dll", CharSet := System.Runtime.InteropServices.CharSet.Auto)> _
    	Private Shared Function SendMessage(hWnd As System.IntPtr, wMsg As Integer, wParam As System.IntPtr, lParam As System.IntPtr) As Integer
    	End Function
    
    	Private Const WM_VSCROLL As Integer = &H115
    	Private Const SB_BOTTOM As Integer = 7
    
    	''' <summary>
    	''' Scrolls the vertical scroll bar of a multi-line text box to the bottom.
    	''' </summary>
    	''' <param name="tb">The text box to scroll</param>
    	Public Shared Sub ScrollToBottom(tb As System.Windows.Forms.TextBox)
    		If System.Environment.OSVersion.Platform <> System.PlatformID.Unix Then
    			SendMessage(tb.Handle, WM_VSCROLL, New System.IntPtr(SB_BOTTOM), System.IntPtr.Zero)
    		End If
    	End Sub
    
    
    End Class
