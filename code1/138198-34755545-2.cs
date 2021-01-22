	Imports System.Runtime.InteropServices
	Public NotInheritable Class KeyboardHook
		Implements IDisposable
		' Registers a hot key with Windows.
		<DllImport("user32.dll")> _
		Private Shared Function RegisterHotKey(hWnd As IntPtr, id As Integer, fsModifiers As UInteger, vk As UInteger) As Boolean
		End Function
		' Unregisters the hot key with Windows.
		<DllImport("user32.dll")> _
		Private Shared Function UnregisterHotKey(hWnd As IntPtr, id As Integer) As Boolean
		End Function
		''' <summary>
		''' Represents the window that is used internally to get the messages.
		''' </summary>
		Private Class Window
			Inherits NativeWindow
			Implements IDisposable
			Private Shared WM_HOTKEY As Integer = &H312
			Public Sub New()
				' create the handle for the window.
				Me.CreateHandle(New CreateParams())
			End Sub
			Public Event KeyPressed As EventHandler(Of KeyPressedEventArgs)
			''' <summary>
			''' Overridden to get the notifications.
			''' </summary>
			''' <param name="m"></param>
			Protected Overrides Sub WndProc(ByRef m As Message)
				MyBase.WndProc(m)
				' check if we got a hot key pressed.
				If m.Msg = WM_HOTKEY Then
					' get the keys.
					Dim key As Keys = DirectCast((CInt(m.LParam) >> 16) And &HFFFF, Keys)
					Dim modifier As ModifierKeys = DirectCast(CUInt(CInt(m.LParam) And &HFFFF), ModifierKeys)
					' invoke the event to notify the parent.
					RaiseEvent KeyPressed(Me, New KeyPressedEventArgs(modifier, key))
				End If
			End Sub
	#Region " IDisposable Members"
			Public Sub Dispose() Implements IDisposable.Dispose
				Me.DestroyHandle()
			End Sub
	#End Region
		End Class
		Private _window As New Window()
		Private _currentId As Integer
		Public Sub New()
			' register the event of the inner native window.
			AddHandler _window.KeyPressed, Sub(sender As Object, args As KeyPressedEventArgs)
											   RaiseEvent KeyPressed(Me, args)
										   End Sub
		End Sub
		''' <summary>
		''' Registers a hot key in the system.
		''' </summary>
		''' <param name="modifier">The modifiers that are associated with the hot key.</param>
		''' <param name="key">The key itself that is associated with the hot key.</param>
		Public Sub RegisterHotKey(modifier As ModifierKeys, key As Keys)
			' increment the counter.
			_currentId = _currentId + 1
			' register the hot key.
			If Not RegisterHotKey(_window.Handle, _currentId, DirectCast(modifier, UInteger), CUInt(key)) Then
				'Throw New InvalidOperationException("Couldn’t register the hot key.")
				'or use MsgBox("Couldn’t register the hot key.")
			End If
		End Sub
		''' <summary>
		''' A hot key has been pressed.
		''' </summary>
		Public Event KeyPressed As EventHandler(Of KeyPressedEventArgs)
	#Region " IDisposable Members"
		Public Sub Dispose() Implements IDisposable.Dispose
			' unregister all the registered hot keys.
			Dim i As Integer = _currentId
			While i > 0
				UnregisterHotKey(_window.Handle, i)
				System.Math.Max(System.Threading.Interlocked.Decrement(i), i + 1)
			End While
			' dispose the inner native window.
			_window.Dispose()
		End Sub
	#End Region
	End Class
	''' <summary>
	''' Event Args for the event that is fired after the hot key has been pressed.
	''' </summary>
	Public Class KeyPressedEventArgs
		Inherits EventArgs
		Private _modifier As ModifierKeys
		Private _key As Keys
		Friend Sub New(modifier As ModifierKeys, key As Keys)
			_modifier = modifier
			_key = key
		End Sub
		Public ReadOnly Property Modifier() As ModifierKeys
			Get
				Return _modifier
			End Get
		End Property
		Public ReadOnly Property Key() As Keys
			Get
				Return _key
			End Get
		End Property
	End Class
	''' <summary>
	''' The enumeration of possible modifiers.
	''' </summary>
	<Flags> _
	Public Enum ModifierKeys As UInteger
		Alt = 1
		Control = 2
		Shift = 4
		Win = 8
	End Enum
