    Public Class MyUserControl
        Inherits System.Web.UI.UserControl
    
		'expose the event publicly
        Public Event UserControlButtonClicked As EventHandler 
    
		'a method to raise the publicly exposed event
        Private Sub OnUserControlButtonClick()
    
            RaiseEvent UserControlButtonClicked(Me, EventArgs.Empty)
    
        End Sub
		Protected Sub lbtnApplyChanges_Click(sender As Object, e As EventArgs) Handles lbtnApplyChanges.Click
		
			'add code to run here, then extend this code by firing off this event
			'so it will trigger the public event handler from the parent page, 
			'and the parent page can hanlde it
			OnUserControlButtonClick()
		
		End Sub
	
	End Class
	
