    Imports System
    Imports System.Drawing
    Imports System.Windows.Forms
    Imports System.Runtime.InteropServices
    
    Public Class MyComboBox
        Inherits ComboBox
    
        'P/Invoke declarations
        Private Structure COMBOBOXINFO
            Public cbSize As Int32
            Public rcItem As RECT
            Public rcButton As RECT
            Public buttonState As Integer
            Public hwndCombo As IntPtr
            Public hwndEdit As IntPtr
            Public hwndList As IntPtr
        End Structure
    
        Private Structure RECT
            Public Left As Integer
            Public Top As Integer
            Public Right As Integer
            Public Bottom As Integer
        End Structure
    
    
        <DllImport("user32.dll", EntryPoint:="SendMessageW", CharSet:=CharSet.Unicode)>
        Private Shared Function SendMessageCb(hWnd As IntPtr, msg As Integer, wp As IntPtr, ByRef lp As COMBOBOXINFO) As IntPtr
        End Function
    
        <DllImport("user32.dll")>
        Private Shared Function SetWindowPos(hWnd As IntPtr, after As IntPtr, x As Integer, y As Integer, cx As Integer, cy As Integer, flags As Integer) As Boolean
        End Function
    
        <DllImport("user32.dll")>
        Private Shared Function GetWindowRect(hWnd As IntPtr, ByRef rc As RECT) As Boolean
        End Function
    
    
        Protected Overrides Sub OnDropDown(e As EventArgs)
              ' Is dropdown off the right side of the screen?
              Dim pos As Point = Me.PointToScreen(Me.Location)
              Dim scr As Screen = Screen.FromPoint(pos)
    
              If (scr.WorkingArea.Right < pos.X + Me.DropDownWidth) Then
                  Me.BeginInvoke(New Action(Sub()
    
                                                'Retrieve handle to dropdown list
                                                Dim info As COMBOBOXINFO = New COMBOBOXINFO()
                                                info.cbSize = Marshal.SizeOf(info)
                                                SendMessageCb(Me.Handle, &H164, IntPtr.Zero, info)
                                                'Move the dropdown window
                                                Dim rc As RECT
                                                GetWindowRect(info.hwndList, rc)
                                                Dim x As Integer = scr.WorkingArea.Right - (rc.Right - rc.Left)
                                                SetWindowPos(info.hwndList, IntPtr.Zero, x, rc.Top, 0, 0, 5)
                                            End Sub))
              End If
    
              MyBase.OnDropDown(e)
    
        End Sub
    
    
    
    End Class
    
    
