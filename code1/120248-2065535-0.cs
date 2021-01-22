    Public Sub TestFuncEx(ByVal oValue As Variant)
    {
       If IsEmpty(oValue) Then
        TestFunc(Nothing)
       Else
        TestFunc(oValue)
       End If
    }
