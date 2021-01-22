	Option Strict On
	Option Explicit On
	Public Class Form1
		Private PreviousTab As TabPage
		Private CurrentTab As TabPage
		Private Sub TabControl1_Deselected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Deselected
			PreviousTab = e.TabPage
			Debug.WriteLine("Deselected: " + e.TabPage.Name)
		End Sub
		Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
			CurrentTab = e.TabPage
			Debug.WriteLine("Selected: " + e.TabPage.Name)
		End Sub
		Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
			If CurrentTab Is Nothing Then Return
			Debug.WriteLine(String.Format("Proposed change from {0} to {1}", CurrentTab.Name, e.TabPage.Name))
		End Sub
	End Class
