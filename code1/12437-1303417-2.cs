    Public Function GetMaxValue _
        (Of TEnum As {IComparable, IConvertible, IFormattable})() As TEnum
        Dim type = GetType(TEnum)
        If Not type.IsSubclassOf(GetType([Enum])) Then _
            Throw New InvalidCastException _
                ("Cannot cast '" & type.FullName & "' to System.Enum.")
        Return [Enum].ToObject(type, [Enum].GetValues(type) _
                            .Cast(Of Integer).Last)
    End Function
