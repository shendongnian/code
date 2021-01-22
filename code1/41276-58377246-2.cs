    Namespace TestingRoutines
    
        ''' <summary>
        ''' Exposes a set of generic tests.
        ''' </summary>
        ''' <typeparam name="T">The type of the object to be tested.</typeparam>
        Public Class GenericTests(Of T)
    
            ''' <summary>
            ''' Exposes a set of  generic tests.
            ''' </summary>
            Sub New()
            End Sub
    
            ''' <summary>
            ''' Asserts a given action on a tested object throws an exception, when and only when the same action on a control object triggers an exception of that same type.
            ''' <para>Note only the exception types are verified, not the content of their message or exception code.</para>
            ''' </summary>
            ''' <param name="ControlObject">The trusted object to compare the behaviour with.</param>
            ''' <param name="TestedObject">The non-trusted object to be tested.</param>
            ''' <param name="Action">The tested action on the objects.</param>
            Public Sub TestExceptionBehaviour(ControlObject As T, TestedObject As T, Action As Action(Of T))
    
                Dim ControlThrowedException As Boolean
    
                Try
                    ControlThrowedException = True
                    Action.Invoke(ControlObject)
                    ControlThrowedException = False
                    Action.Invoke(TestedObject)
                Catch ex As Exception
                    If Not ControlThrowedException Then Assert.Fail($"Unexpected exception. The tested object threw an exception whilst the control object did not: {ex.ToString}")
                    Try
                        Action.Invoke(TestedObject)
                        Assert.Fail($"Expected exception. The control object threw an exception whilst the tested object did not: {ex.ToString}")
                    Catch ex2 As Exception
                        If ex.GetType <> ex2.GetType Then Assert.Fail($"Exception types mismatch. The control object threw an exception of type '{ex.GetType.ToString}' whilst the tested object threw an exception of type '{ex2.GetType.ToString}'.")
                    End Try
                End Try
    
            End Sub
    
        End Class
    
    
    End Namespace
