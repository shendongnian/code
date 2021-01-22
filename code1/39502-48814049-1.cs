	Public Class SalesRecord
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
			'hook up event handler for exposed user control event to handle this
			AddHandler MyUserControl.UserControlButtonClicked, AddressOf MyUserControl_UserControlButtonClicked
		End Sub
		''' <summary>
		''' code to run when user clicks 'lbtnApplyChanges' on the user control
		''' </summary>
		Private Sub MyUserControl_UserControlButtonClicked()
			'this code will now fire when lbtnApplyChanges_Click executes
		End Sub
		
	End Class
