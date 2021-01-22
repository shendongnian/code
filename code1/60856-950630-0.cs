    Protected ReadOnly Property MyService() As MyServiceClient
        Get
            ' Initialise My Service and return it
            If m_objMyService Is Nothing OrElse m_objMyService.State = CommunicationState.Closed OrElse m_objMyService.State = CommunicationState.Faulted Then
                m_objMyService = MethodToGetServiceClient(Of MyServiceClient, MyService)()
            End If
            Return m_objMyService
        End Get
    End Property
