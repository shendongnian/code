    ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf GetGreeting))
    
    Private Sub GetGreeting(o As Object)
        Dim channelFactory = New ChannelFactory(Of ISimpleService)("*")
        Dim simpleService = channelFactory.CreateChannel()
        Dim asyncResult = simpleService.BeginGetGreeting("Daniel", Nothing, Nothing)
        Dim greeting As String = Nothing
        Begin Try
            greeting = simpleService.EndGetGreeting(asyncResult)
        Catch ex As Exception
            DisplayMessage(String.Format("Unable to communicate with server. {0} {1}", ex.Message, ex.StackTrace))
        End Try
        DisplayGreeting(greeting)
    End Sub
