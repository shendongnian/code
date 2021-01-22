    Public Class RestartableServiceHost
    	Inherits ServiceHost
    
    	Private m_Log As FileLogger
    	Private ReadOnly m_FaultResponse As ServiceHostFaultResponse
    	Private ReadOnly m_Name As String
    
    	Public Sub New(ByVal serviceType As Type, ByVal faultResponse As ServiceHostFaultResponse, ByVal log As FileLogger)
    		MyBase.New(serviceType)
    		If serviceType Is Nothing Then Throw New ArgumentNullException("serviceType", "serviceType is nothing.")
    		If log Is Nothing Then Throw New ArgumentNullException("log", "log is nothing.")
    
    
    		m_Log = log
    		m_FaultResponse = faultResponse
    		m_Name = serviceType.Name & " service host"
    	End Sub
    
    	Public Sub New(ByVal singletonInstance As Object, ByVal faultResponse As ServiceHostFaultResponse, ByVal log As FileLogger)
    		MyBase.New(singletonInstance)
    
    		If singletonInstance Is Nothing Then Throw New ArgumentNullException("singletonInstance", "singletonInstance is nothing.")
    		If log Is Nothing Then Throw New ArgumentNullException("log", "log is nothing.")
    
    		m_Log = log
    		m_FaultResponse = faultResponse
    		m_Name = singletonInstance.GetType.Name & " service host"
    	End Sub
    
    	Private Sub AamServiceHost_Closed(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closed
    		m_Log.Write(m_Name & " has closed")
    	End Sub
    
    	Private Sub AamServiceHost_Closing(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Closing
    		m_Log.Write(m_Name & " is closing")
    	End Sub
    
    	Private Sub AamServiceHost_Faulted(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Faulted
    		m_Log.Write(m_Name & " has faulted.")
    
    		Select Case m_FaultResponse
    			Case ServiceHostFaultResponse.None
    				'NOP
    			Case ServiceHostFaultResponse.AbortReopenThrow
    				Try
    					Abort()
    				Catch ex As Exception
    					m_Log.Write("Unable to abort SecurityMasterChangeListener Service Host", ex, Severity.Warning)
    				End Try
    				Threading.Thread.Sleep(TimeSpan.FromSeconds(30))
    				Try
    					Open()
    				Catch ex As Exception
    					m_Log.Write("Unable to reopen SecurityMasterChangeListener Service Host.", ex, Severity.ErrorServiceFailed)
    					Throw
    				End Try
    		End Select
    
    	End Sub
    
    	Private Sub AamServiceHost_Opened(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Opened
    		m_Log.Write(m_Name & " has opened")
    	End Sub
    
    	Private Sub AamServiceHost_Opening(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Opening
    		m_Log.Write(m_Name & " is opening")
    	End Sub
    
    	Private Sub AamServiceHost_UnknownMessageReceived(ByVal sender As Object, ByVal e As UnknownMessageReceivedEventArgs) Handles Me.UnknownMessageReceived
    		m_Log.Write("SecurityMasterChangeListener Service Host has received an unknown message. The message will be ignored.", Severity.ErrorTaskFailed)
    	End Sub
    
    End Class
