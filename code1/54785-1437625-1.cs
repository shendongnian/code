    Private Sub list_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles list.MouseClick
		Dim item As ListViewItem = list.GetItemAt(e.X, e.Y)
		If Not IsNothing(item) Then
			do your stuff here
		End If
	End Sub
