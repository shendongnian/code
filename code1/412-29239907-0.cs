    Public Function CloneObject(Of T As New)(ByVal src As T) As T
        Dim result As T = Nothing
        Dim cloneable = TryCast(src, ICloneable)
        If cloneable IsNot Nothing Then
            result = cloneable.Clone()
        Else
            result = New T
            CopySimpleProperties(src, result, Nothing, "clone")
        End If
        Return result
    End Function
