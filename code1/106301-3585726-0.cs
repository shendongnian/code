    Public Class Foo
    
         Public Shared Function GetMyPath() As String
              Return Path.GetDirectoryName(GetType(Foo).Assembly.Location)
         End Function
    End Class
