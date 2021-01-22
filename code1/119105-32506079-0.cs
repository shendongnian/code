    Imports System.Runtime.InteropServices
    Imports System.ComponentModel
	Public Class MyRichTextBox
		Inherits Windows.Forms.RichTextBox
		Public Const WM_USER As Integer = &H400
		Public Const EM_SETTEXTMODE As Integer = WM_USER + 89
		Public Const EM_GETTEXTMODE As Integer = WM_USER + 90
		'EM_SETTEXTMODE/EM_GETTEXTMODE flags
		Public Const TM_PLAINTEXT As Integer = 1
		Public Const TM_RICHTEXT As Integer = 2          ' Default behavior 
		Public Const TM_SINGLELEVELUNDO As Integer = 4
		Public Const TM_MULTILEVELUNDO As Integer = 8    ' Default behavior 
		Public Const TM_SINGLECODEPAGE As Integer = 16
		Public Const TM_MULTICODEPAGE As Integer = 32    ' Default behavior
		<DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
		Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
		End Function
		Private _plainTextMode As Boolean = False
		<DefaultValue(False),
		  Browsable(True)>
		Public Property PlainTextMode As Boolean
			Get
				Return _plainTextMode
			End Get
			Set(value As Boolean)
				_plainTextMode = value
				If (Me.IsHandleCreated) Then
					Dim mode As IntPtr = If(value, TM_PLAINTEXT, TM_RICHTEXT)
					SendMessage(Handle, EM_SETTEXTMODE, mode, IntPtr.Zero)
				End If
			End Set
		End Property
		Protected Overrides Sub OnHandleCreated(e As EventArgs)
			'For some reason it worked for me only if I manipulated the created
			'handle before calling the base method.
			Me.PlainTextMode = _plainTextMode
			MyBase.OnHandleCreated(e)
		End Sub
	End Class
