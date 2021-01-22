    Public Class MyClass  
        Public Delegate Function Getter(Of TResult)() As TResult    
    
        Private MyGetter As Getter(Of TResult)
        Public Shared Sub MyMethod(Of TResult)(ByVal g As Getter(Of TResult))
            MyGetter = g  
        End Sub
    End Class
