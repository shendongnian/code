    Public Class MyClass
      Shared Sub New()
        Reset
      End Sub
      Private Sub New()
        ' Prevent instantiation of the class
      End Sub
      
      Public Sub Reset()
        Field1 = 42
        Field2 = "foo"
      End Sub
      
      Public Shared Field1 As Integer
      Public Shared Field2 As String
    End Class
