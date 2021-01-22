    Public Sub TestFunc(ByVal oValue As Variant)
     {
       ...
       If oValue Is Nothing Then
         Set oValue = someObject
       ElseIf IsEmpty(oValue) Then
         Set oValue = someObject
       End If
       ...
    
     }
