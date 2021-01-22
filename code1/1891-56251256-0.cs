            <Extension()>
        Public Function ToEnum(Of TEnum)(ByVal value As String, ByVal defaultValue As TEnum) As TEnum
            If String.IsNullOrEmpty(value) Then
                Return defaultValue
            End If
            Return [Enum].Parse(GetType(TEnum), value, True)
        End Function
