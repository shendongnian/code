    Private _something As EventHandler = Nothing
    
    Public Custom Event Something As EventHandler
    	AddHandler(ByVal value As EventHandler)
    		Me._something = DirectCast(System.Delegate.Combine(Me._something, DirectCast(value, EventHandler)), EventHandler)
    	End AddHandler
    	RemoveHandler(ByVal value As EventHandler)
    		Me._something = DirectCast(System.Delegate.Remove(Me._something, DirectCast(value, EventHandler)), EventHandler)
    	End RemoveHandler
    	RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    		If Me._something IsNot Nothing Then
    			For Each d As EventHandler In Me._something.GetInvocationList()
    				d.Invoke(sender, e)
    			Next d
    		End If
    	End RaiseEvent
    End Event
