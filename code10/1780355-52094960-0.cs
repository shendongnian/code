	Public Class Form2
		Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Me.FormBorderStyle = FormBorderStyle.None
			Me.DoubleBuffered = True
			Me.SetStyle(ControlStyles.ResizeRedraw, True)
		End Sub
		Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
			e.Graphics.FillRectangle(Brushes.Green, Top)
			e.Graphics.FillRectangle(Brushes.Green, Left)
			e.Graphics.FillRectangle(Brushes.Green, Right)
			e.Graphics.FillRectangle(Brushes.Green, Bottom)
		End Sub
		Private Const HTLEFT As Integer = 10, HTRIGHT As Integer = 11, HTTOP As Integer = 12, HTTOPLEFT As Integer = 13, HTTOPRIGHT As Integer = 14, HTBOTTOM As Integer = 15, HTBOTTOMLEFT As Integer = 16, HTBOTTOMRIGHT As Integer = 17
		Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
			MyBase.WndProc(m)
			If m.Msg = &H84 Then
				Dim mp = Me.PointToClient(Cursor.Position)
				If TopLeft.Contains(mp) Then
					m.Result = CType(HTTOPLEFT, IntPtr)
				ElseIf TopRight.Contains(mp) Then
					m.Result = CType(HTTOPRIGHT, IntPtr)
				ElseIf BottomLeft.Contains(mp) Then
					m.Result = CType(HTBOTTOMLEFT, IntPtr)
				ElseIf BottomRight.Contains(mp) Then
					m.Result = CType(HTBOTTOMRIGHT, IntPtr)
				ElseIf Top.Contains(mp) Then
					m.Result = CType(HTTOP, IntPtr)
				ElseIf Left.Contains(mp) Then
					m.Result = CType(HTLEFT, IntPtr)
				ElseIf Right.Contains(mp) Then
					m.Result = CType(HTRIGHT, IntPtr)
				ElseIf Bottom.Contains(mp) Then
					m.Result = CType(HTBOTTOM, IntPtr)
				End If
			End If
		End Sub
		Dim rng As New Random
		Function randomColour() As Color
			Return Color.FromArgb(255, rng.Next(255), rng.Next(255), rng.Next(255))
		End Function
		Const ImaginaryBorderSize As Integer = 16
		Function Top() As Rectangle
			Return New Rectangle(0, 0, Me.ClientSize.Width, ImaginaryBorderSize)
		End Function
		Function Left() As Rectangle
			Return New Rectangle(0, 0, ImaginaryBorderSize, Me.ClientSize.Height)
		End Function
		Function Bottom() As Rectangle
			Return New Rectangle(0, Me.ClientSize.Height - ImaginaryBorderSize, Me.ClientSize.Width, ImaginaryBorderSize)
		End Function
		Function Right() As Rectangle
			Return New Rectangle(Me.ClientSize.Width - ImaginaryBorderSize, 0, ImaginaryBorderSize, Me.ClientSize.Height)
		End Function
		Function TopLeft() As Rectangle
			Return New Rectangle(0, 0, ImaginaryBorderSize, ImaginaryBorderSize)
		End Function
		Function TopRight() As Rectangle
			Return New Rectangle(Me.ClientSize.Width - ImaginaryBorderSize, 0, ImaginaryBorderSize, ImaginaryBorderSize)
		End Function
		Function BottomLeft() As Rectangle
			Return New Rectangle(0, Me.ClientSize.Height - ImaginaryBorderSize, ImaginaryBorderSize, ImaginaryBorderSize)
		End Function
		Function BottomRight() As Rectangle
			Return New Rectangle(Me.ClientSize.Width - ImaginaryBorderSize, Me.ClientSize.Height - ImaginaryBorderSize, ImaginaryBorderSize, ImaginaryBorderSize)
		End Function
	End Class
