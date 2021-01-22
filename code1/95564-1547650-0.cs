    Public Shared Function CastTypeOrNull(Of T)(ByVal castMe As Object) As T
        If (castMe Is Nothing Or castMe.GetType Is GetType(System.DBNull)) Then
            Return Nothing
        Else
            Return CType(castMe, T)
        End If
    End Function
