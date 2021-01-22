    Private Class ExceptionLogger
      Private _ex As Exception
      Public Sub New(ByVal ex As Exception)
        _ex = ex
      End Sub
      Public Sub DoLog()
        Console.WriteLine(_ex.ToString) '//Will display en-US message
      End Sub
    End Class
