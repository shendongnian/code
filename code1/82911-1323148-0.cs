        Public Function Invoke(ByVal instance As Object, ByVal inputs As Object(), ByRef outputs As Object()) As Object Implements System.ServiceModel.Dispatcher.IOperationInvoker.Invoke
            Dim staOutputs As Object() = Nothing
            Dim retval As Object = Nothing
            Dim thread As New Thread(AddressOf DoWork)
            _instance = instance
            _inputs = inputs
            _staOutPuts = staOutputs
            thread.SetApartmentState(ApartmentState.STA)
            thread.Start()
            thread.Join()
            outputs = staOutputs
            Return retval
        End Function
    
        Private Function DoWork() As Object
            Return _innerInvoker.Invoke(_instance, _inputs, _staOutPuts)
        End Function
