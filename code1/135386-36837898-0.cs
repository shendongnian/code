    Sub DoSomething()
      Static obj As Object
      If obj Is Nothing Then obj = New Object
      Console.WriteLine(obj.ToString())
    End Sub  
