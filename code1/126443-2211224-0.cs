	Friend Sub HighlightRequiredFields(ByVal pnlContainer As Panel, ByVal gr As Graphics, ByVal fVisible As Boolean)
		Dim rect As Rectangle
		For Each oControl As Control In pnlContainer.Controls
			If TypeOf oControl.Tag Is String AndAlso oControl.Tag.ToString = "required" Then
				rect = oControl.Bounds
				rect.Inflate(1, 1)
				If fVisible Then
					ControlPaint.DrawBorder(gr, rect, Color.Red, ButtonBorderStyle.Solid)
				Else
					ControlPaint.DrawBorder(gr, rect, pnlContainer.BackColor, ButtonBorderStyle.None)
				End If
			End If
			If TypeOf oControl Is Panel Then HighlightRequiredFields(DirectCast(oControl, Panel), gr, fVisible)
		Next
	End Sub
