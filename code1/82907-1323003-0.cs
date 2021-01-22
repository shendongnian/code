    Friend Class Program
    ' Methods
    Private Shared Function Foo(ByVal instance As Object, ByVal inputs As Object(), <Out> ByRef outputs As Object()) As Object
        outputs = Nothing
        Return Nothing
    End Function
    Public Function Invoke(ByVal instance As Object, ByVal inputs As Object(), <Out> ByRef outputs As Object()) As Object
        Dim staOutputs As Object() = Nothing
        Dim retval As Object = Nothing
        Dim thread As New Thread(Function 
            retval = Me._innerInvoker.Invoke(instance, inputs, staOutputs)
        End Function)
        thread.SetApartmentState(ApartmentState.STA)
        thread.Start
        thread.Join
        outputs = staOutputs
        Return retval
    End Function
    ' Fields
    Private _innerInvoker As MyInvoker = New MyInvoker(AddressOf Program.Foo)
    End Class
    <CompilerGenerated> _
    Private NotInheritable Class <>c__DisplayClass1
    ' Methods
    Public Sub <Invoke>b__0()
        Me.retval = Me.<>4__this._innerInvoker.Invoke(Me.instance, Me.inputs, Me.staOutputs)
    End Sub
    ' Fields
    Public <>4__this As Program
    Public inputs As Object()
    Public instance As Object
    Public retval As Object
    Public staOutputs As Object()
    End Class
 
