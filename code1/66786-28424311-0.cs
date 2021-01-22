    Imports System.ServiceModel
    Imports System.ServiceModel.Channels
    
    
    
    Public Interface IMyContractCallback
        <OperationContract()> _
        Sub OnCallBack()
    End Interface
    
    <ServiceContract(CallBackContract:=GetType(IMyContractCallback))> _
    Public Interface IMyContract
        <OperationContract()> _
        Sub DoSomething()
    End Interface
    
    <ServiceBehavior(ConcurrencyMode:=ConcurrencyMode.Reentrant)> _
    Public Class Myservice
        Implements IMyContract
    
        Public Sub DoSomething() Implements IMyContract.DoSomething
            Console.WriteLine("Hi from server!")
            Dim callback As IMyContractCallback = OperationContext.Current.GetCallbackChannel(Of IMyContractCallback)()
            callback.OnCallBack()
        End Sub
    End Class
    
    Public Class MyContractClient
        Inherits DuplexClientBase(Of IMyContract)
    
        Public Sub New(ByVal callbackinstance As Object, ByVal binding As Binding, ByVal remoteAddress As EndpointAddress)
            MyBase.New(callbackinstance, binding, remoteAddress)
        End Sub
    End Class
    
    Public Class MyCallbackClient
        Implements IMyContractCallback
    
        Public Sub OnCallBack() Implements IMyContractCallback.OnCallBack
            Console.WriteLine("Hi from client!")
        End Sub
    End Class
    
    
    Module Module1
    
        Sub Main()
            Dim uri As New Uri("net.tcp://localhost")
            Dim binding As New NetTcpBinding()
            Dim host As New ServiceHost(GetType(Myservice), uri)
            host.AddServiceEndpoint(GetType(IMyContract), binding, "")
            host.Open()
    
            Dim callback As New MyCallbackClient()
            Dim client As New MyContractClient(callback, binding, New EndpointAddress(uri))
            Dim proxy As IMyContract = client.ChannelFactory.CreateChannel()
    
            proxy.DoSomething()
            ' Printed in console:
            '  Hi from server!
            '  Hi from client!
    
            Console.ReadLine()
    
            client.Close()
            host.Close()
        End Sub
    
    End Module
