     Dim myFactory As ChannelFactory(Of SimpleService.IService1)
        myFactory = New ChannelFactory(Of SimpleService.IService1)(myBinding, myEndpoint)
        oProxy = myFactory.CreateChannel()
        'commented out version that does same call without reflection
        ' oProxy.GetData(3)
       Dim oType As Type = oProxy.GetType
       Dim oMeth As MethodInfo = oType.GetMethod("GetData")
       Dim params() As Object = {3}
       Dim sResults As String
       sResults = oMeth.Invoke(oProxy, BindingFlags.Public Or BindingFlags.InvokeMethod, Nothing, params, System.Globalization.CultureInfo.CurrentCulture)
       
