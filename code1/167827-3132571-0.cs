    Public Sub Main()
      Dim big As Variant
      Set big = GetReallyBigObject()
      Call big.DoSomething
      Set big = Nothing
      Call TimeConsumingOperation
      Call ConsumeMoreMemory
    End Sub
