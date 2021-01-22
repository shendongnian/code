    Module ISynchronizeInvokeExtensions
        Public Delegate Function GenericLambdaFunctionWithParam(Of InputType, OutputType)(ByVal input As InputType) As OutputType
        Private Delegate Function InvokeLambdaFunctionCallback(Of InputType, OutputType)(ByVal f As GenericLambdaFunctionWithParam(Of InputType, OutputType), ByVal input As InputType, ByVal c As System.ComponentModel.ISynchronizeInvoke) As OutputType
        Public Function InvokeEx(Of InputType, OutputType)(ByVal f As GenericLambdaFunctionWithParam(Of InputType, OutputType), ByVal input As InputType, ByVal c As System.ComponentModel.ISynchronizeInvoke) As OutputType
            If c.InvokeRequired Then
                Dim d As New InvokeLambdaFunctionCallback(Of InputType, OutputType)(AddressOf InvokeEx)
                Return DirectCast(c.Invoke(d, New Object() {f, input, c}), OutputType)
            Else
                Return f(input)
            End If
        End Function
        Public Delegate Sub GenericLambdaSubWithParam(Of InputType)(ByVal input As InputType)
        Public Sub InvokeEx(Of InputType)(ByVal s As GenericLambdaSubWithParam(Of InputType), ByVal input As InputType, ByVal c As System.ComponentModel.ISynchronizeInvoke)
            InvokeEx(Of InputType, Object)(Function(i As InputType) As Object
                                               s(i)
                                               Return Nothing
                                           End Function, input, c)
        End Sub
        Public Delegate Sub GenericLambdaSub()
        Public Sub InvokeEx(ByVal s As GenericLambdaSub, ByVal c As System.ComponentModel.ISynchronizeInvoke)
            InvokeEx(Of Object, Object)(Function(i As Object) As Object
                                            s()
                                            Return Nothing
                                        End Function, Nothing, c)
        End Sub
        Public Delegate Function GenericLambdaFunction(Of OutputType)() As OutputType
        Public Function InvokeEx(Of OutputType)(ByVal f As GenericLambdaFunction(Of OutputType), ByVal c As System.ComponentModel.ISynchronizeInvoke) As OutputType
            Return InvokeEx(Of Object, OutputType)(Function(i As Object) f(), Nothing, c)
        End Function
    End Module
