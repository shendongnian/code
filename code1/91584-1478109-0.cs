    Public Shared Function Coalesce(Of T)(ByVal value As T, ByVal NullValue As T) As T
        If value Is Nothing Then : Return NullValue
        Else : Return value
        End If
    End Function
