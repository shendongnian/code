        Private myThreadingTimer As System.Threading.Timer
        Private blnCurrentlyRunning As Boolean = False
    
        Protected Overrides Sub OnStart(ByVal args() As String)
           Dim myTimerCallback As New TimerCallback(AddressOf OnTimedEvent)
           myThreadingTimer = New System.Threading.Timer(myTimerCallback, Nothing, 1000, 1000)
        End Sub
    
        Private Sub OnTimedEvent(ByVal state As Object)
            If Date.Now.Second = 1 Or Date.Now.Second = 15 Or Date.Now.Second = 30 Or Date.Now.Second = 45 Then
                If Not blnCurrentlyRunning Then
                    blnCurrentlyRunning = True
    
                    Dim myNewThread As New Thread(New ThreadStart(AddressOf MyFunctionIWantToCall))
                    myNewThread.Start()
                End If
            End If
        End Sub
    
    Public Sub MyFunctionIWantToCall()
       Try
           'Do Something
       Catch ex As Exception
       Finally
           blnCurrentlyRunning = False
       End Try
    End Sub
