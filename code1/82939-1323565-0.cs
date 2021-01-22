	Option Strict On
	Option Explicit On
	Public Class Form1
		Private PreviousTab As TabPage
		Private CurrentTab As TabPage
		Private Sub TabControl1_Deselected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Deselected
			PreviousTab = e.TabPage
		End Sub
		Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
			CurrentTab = e.TabPage
		End Sub
	End Class
