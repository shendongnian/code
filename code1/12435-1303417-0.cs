    <Extension()> _
    Public Function GetMaxValue(Of TEnum As {IComparable, IConvertible, IFormattable})(ByVal [enum] As TEnum, ByVal value As TEnum) As TEnum
        If Not TypeOf [enum] Is System.Enum Then Throw New InvalidCastException("Cannot cast '" & GetType(TEnum).FullName & "' to System.Enum.")
        System.Enum.GetValues(GetType(TEnum)).Cast(Of Integer).Last()
    End Function
