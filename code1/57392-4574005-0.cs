    Public Class Form1
        '''<summary>
        '''Returns a handle to the foreground window.
        '''</summary>
        <Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True)> _
        Private Shared Function GetForegroundWindow() As IntPtr
        End Function
    
        '''<summary>
        '''Gets a value indicating whether this instance is foreground window.
        '''</summary>
        '''<value>
        '''<c>true</c> if this is the foreground window; otherwise, <c>false</c>.
        '''</value>
        Private ReadOnly Property IsForegroundWindow As Boolean
            Get
                Dim foreWnd = GetForegroundWindow()
                Return ((From f In Me.MdiChildren Select f.Handle).Union(
                        From f In Me.OwnedForms Select f.Handle).Union(
                        {Me.Handle})).Contains(foreWnd)
            End Get
        End Property
    End Class
