    Public Shared Iterator Function FindVisualChildren(Of T As DependencyObject)(depObj As DependencyObject) As IEnumerable(Of T)
		If depObj IsNot Nothing Then
			For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(depObj) - 1
				Dim child As DependencyObject = VisualTreeHelper.GetChild(depObj, i)
				If child IsNot Nothing AndAlso TypeOf child Is T Then
					Yield DirectCast(child, T)
				End If
				For Each childOfChild As T In FindVisualChildren(Of T)(child)
					Yield childOfChild
				Next
			Next
		End If
	End Function
