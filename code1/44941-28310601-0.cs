    Imports System.Runtime.InteropServices
    Imports System.Windows.Forms
    Imports System.Windows.Forms.VisualStyles
    Imports System.Drawing
    Imports System.Diagnostics
    
    Public Class FlatRichTextBox
        Inherits RichTextBox
    
        Private BorderRect As RECT
    
        Sub New()
            If VisualStyleInformation.IsEnabledByUser Then
                BorderStyle = BorderStyle.None
            End If
        End Sub
    
        Protected Overrides Sub WndProc(ByRef m As Message)
            Const WM_NCPAINT = &H85
            Const WM_NCCALCSIZE = &H83
            Const WM_THEMECHANGED = &H31A
    
            Select Case m.Msg
                Case WM_NCPAINT
                    WmNcpaint(m)
                Case WM_NCCALCSIZE
                    WmNccalcsize(m)
                Case WM_THEMECHANGED
                    UpdateStyles()
                Case Else
                    MyBase.WndProc(m)
            End Select
        End Sub
    
        Private Sub WmNccalcsize(ByRef m As Message)
            MyBase.WndProc(m)
    
            If Not VisualStyleInformation.IsEnabledByUser Then Return
    
            Dim par As New NCCALCSIZE_PARAMS()
            Dim windowRect As RECT
    
            If m.WParam <> IntPtr.Zero Then
                par = CType(Marshal.PtrToStructure(m.LParam, GetType(NCCALCSIZE_PARAMS)), NCCALCSIZE_PARAMS)
                windowRect = par.rgrc0
            End If
    
            Dim clientRect = windowRect
    
            clientRect.Left += 1
            clientRect.Top += 1
            clientRect.Right -= 1
            clientRect.Bottom -= 1
    
            BorderRect = New RECT(clientRect.Left - windowRect.Left,
                                  clientRect.Top - windowRect.Top,
                                  windowRect.Right - clientRect.Right,
                                  windowRect.Bottom - clientRect.Bottom)
    
            If m.WParam = IntPtr.Zero Then
                Marshal.StructureToPtr(clientRect, m.LParam, False)
            Else
                par.rgrc0 = clientRect
                Marshal.StructureToPtr(par, m.LParam, False)
            End If
    
            Const WVR_HREDRAW = &H100
            Const WVR_VREDRAW = &H200
            Const WVR_REDRAW = (WVR_HREDRAW Or WVR_VREDRAW)
    
            m.Result = New IntPtr(WVR_REDRAW)
        End Sub
    
        Private Sub WmNcpaint(ByRef m As Message)
            MyBase.WndProc(m)
    
            If Not VisualStyleInformation.IsEnabledByUser Then Return
    
            Dim r As RECT
            GetWindowRect(Handle, r)
    
            r.Right -= r.Left
            r.Bottom -= r.Top
            r.Top = 0
            r.Left = 0
    
            r.Left += BorderRect.Left
            r.Top += BorderRect.Top
            r.Right -= BorderRect.Right
            r.Bottom -= BorderRect.Bottom
    
            Dim hDC = GetWindowDC(Handle)
            ExcludeClipRect(hDC, r.Left, r.Top, r.Right, r.Bottom)
    
            Using g = Graphics.FromHdc(hDC)
                g.Clear(Color.CadetBlue)
            End Using
    
            ReleaseDC(Handle, hDC)
            m.Result = IntPtr.Zero
        End Sub
    
        <DllImport("user32.dll")>
        Public Shared Function GetWindowRect(hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
        End Function
    
        <DllImport("user32.dll")>
        Public Shared Function GetWindowDC(hWnd As IntPtr) As IntPtr
        End Function
    
        <DllImport("user32.dll")>
        Public Shared Function ReleaseDC(hWnd As IntPtr, hDC As IntPtr) As Integer
        End Function
    
        <DllImport("gdi32.dll")>
        Public Shared Function ExcludeClipRect(hdc As IntPtr, nLeftRect As Integer, nTopRect As Integer, nRightRect As Integer, nBottomRect As Integer) As Integer
        End Function
    
        <StructLayout(LayoutKind.Sequential)>
        Public Structure NCCALCSIZE_PARAMS
            Public rgrc0, rgrc1, rgrc2 As RECT
            Public lppos As IntPtr
        End Structure
    
        <StructLayout(LayoutKind.Sequential)>
        Public Structure RECT
            Public Left As Integer
            Public Top As Integer
            Public Right As Integer
            Public Bottom As Integer
    
            Public Sub New(left As Integer, top As Integer, right As Integer, bottom As Integer)
                Me.Left = left
                Me.Top = top
                Me.Right = right
                Me.Bottom = bottom
            End Sub
        End Structure
    End Class
