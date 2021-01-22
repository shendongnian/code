    Imports System
    
    Class MainClass
      Public Function FunctionOne(arg1 As String, arg2 As String) As Integer
        Return Int32.Parse(arg1) + Int32.Parse(arg2)
      End Function
      Public Sub FunctionOne(arg1 As Integer, arg2 As Integer)
        Return
      End Sub
    End Class
