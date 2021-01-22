    Class Inches
        Private _value As Integer
        Public ReadOnly Property Value() As Integer
            Get
                Return _value
            End Get
        End Property
        Public Sub New(ByVal x As Integer)
            _value = x
        End Sub
    
        Public Shared Widening Operator CType(ByVal x As Integer) As Inches
            Return New Inches(x)
        End Operator
    
        Public Shared Widening Operator CType(ByVal x As Inches) As Integer
            Return x.Value
        End Operator
    End Class
