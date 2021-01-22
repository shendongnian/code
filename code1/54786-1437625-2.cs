    Private Sub list_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles list.MouseMove
		Dim item As ListViewItem = list.GetItemAt(e.X, e.Y)
		If Not IsNothing(item) Then
			list.SelectedItems.Clear()
			item.Selected = True
		End If
	End Sub
