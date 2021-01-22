    Class InnerInvokerClosure
        Public instance As Object
        Public inputs() As Object
        Public staOutputs() As Object
        Public retValue As Object
        
        Public _innerInvoker As SomeDelegateType
        Sub New(ByRef instance as Object, ByRef inputs() as Object, ByRef staOutputs() As Object, ByRef retValue As Object, ByRef _innerInvoker As SomeDelegateType)
            Me.instance = instance
            Me.inputs = inputs
            Me.staOoutputs = staOutputs
            Me.retValue = retValue
            Me._innerInvoker = _innerInvoker
        End Sub
        Public Function Invoke() As Object
            retValue = _innerInvoker.Invoke(instance, inputs, staOutputs);
        End Function
    End Class
    Public Function Invoke(ByVal instance As Object, ByVal inputs() as Object, ByRef outputs() As Object) As Object
        Dim closure As New InnerInvokerClosure(instance, inputs, Nothing, Nothing, _innerInvoker)
        Dim t As New Thread(AddressOf closure.Invoke)
        t.SetApartmentState(ApartmentState.STA)
        t.Start()
        t.Join()
        outputs = closure.staOutputs
        return closure.retValue      
    End Function
