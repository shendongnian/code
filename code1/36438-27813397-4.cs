    Namespace Service
      Public NotInheritable Class Disposable(Of T)
        Public Shared ChannelFactory As New ChannelFactory(Of T)(Service)
        Public Shared Sub Use(Execute As Action(Of T))
          Dim oProxy As IClientChannel
          oProxy = ChannelFactory.CreateChannel
          Try
            Execute(oProxy)
            oProxy.Close()
          Catch
            oProxy.Abort()
            Throw
          End Try
        End Sub
        Public Shared Function Use(Of TResult)(Execute As Func(Of T, TResult)) As TResult
          Dim oProxy As IClientChannel
          oProxy = ChannelFactory.CreateChannel
          Try
            Use = Execute(oProxy)
            oProxy.Close()
          Catch
            oProxy.Abort()
            Throw
          End Try
        End Function
        Public Shared ReadOnly Property Service As ServiceEndpoint
          Get
            Return New ServiceEndpoint(
              ContractDescription.GetContract(
                GetType(T),
                GetType(Action(Of T))),
              New BasicHttpBinding,
              New EndpointAddress(Utils.WcfUri.ToString))
          End Get
        End Property
      End Class
    End Namespace
