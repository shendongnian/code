    Public Sub Test1(ByVal value As Integer)
        SetValue(Of Integer)(value, _intValue)
    End Sub
    
    Public Sub Test2(ByVal value As Nullable(Of Integer))
        SetValue(Of Integer)(value, _intNullableValue)
    End Sub
