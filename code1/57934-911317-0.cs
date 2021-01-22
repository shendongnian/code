    Public Function AfterReceiveRequest(ByRef request As System.ServiceModel.Channels.Message, ByVal channel As System.ServiceModel.IClientChannel, ByVal instanceContext As System.ServiceModel.InstanceContext) As Object Implements System.ServiceModel.Dispatcher.IDispatchMessageInspector.AfterReceiveRequest
        'Output the request message to immediate window
        System.Diagnostics.Debug.WriteLine("*** SERVER - RECEIVED REQUEST ***")
        System.Diagnostics.Debug.WriteLine(request.ToString())
        Return Nothing
    End Function
