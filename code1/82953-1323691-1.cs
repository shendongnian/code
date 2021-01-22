	Option Strict On
	Option Explicit On
	Public Class Form1
		Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As SelectedTabChangingEventArgs) Handles TabControl1.Selecting
			If e.CurrentTab Is Nothing Then Return
			Console.WriteLine(String.Format("Proposed change from {0} to {1}", e.CurrentTab.Name, e.TabPage.Name))
		End Sub
		Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As SelectedTabChangedEventArgs) Handles TabControl1.Selected
			Console.WriteLine(String.Format("Changed from {0} to {1}", e.PreviousTab.Name, e.TabPage.Name))
		End Sub
	End Class
