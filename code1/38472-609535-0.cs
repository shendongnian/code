    Public Class EqualsTestComparer
    Implements IEqualityComparer(Of EqualsTestClass)
    Public Function Equals1(ByVal x As EqualsTestClass, ByVal y As EqualsTestClass) As Boolean Implements System.Collections.Generic.IEqualityComparer(Of EqualsTestClass).Equals
        If x.MyId  = y.MyId and x.MyDescription = y.MyDescription  Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function GetHashCode1(ByVal obj As EqualsTestClass) As Integer Implements System.Collections.Generic.IEqualityComparer(Of EqualsTestClass).GetHashCode
        Return obj.ToString.ToLower.GetHashCode
    End Function    
    End Class
