    Public Function Fields(Optional ByVal key As Object = Nothing) As Object
        If key Is Nothing Then
            Return New clsFieldProperties(_dtData.Columns.Count)
        Else
            Return strarray(key)
        End If
    End Function
