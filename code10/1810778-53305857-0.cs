    Module Module1
    
        Sub Main()
    
            Dim o As New Test
    
            o.DoSomething(Sub(paramName) Console.WriteLine("The id is {0}", paramName))
    
        End Sub
    
    End Module
    
    Class Test
    
        Public Property ID As Integer = 10
    
        Delegate Sub SomeDelegate(ByVal id As Integer)
    
        Public Function DoSomething(ByVal f As SomeDelegate) As Test
    
            f(Me.ID)
    
            Return Me
        End Function
    
    End Class
