    Public Shared Function FirstValueOrDefault(Of T) (ByVal Int ID) As T
        Dim r as datarow = ItemTable.Select("Id = " + id.ToString());
        If r.IsNull(0) Then
            If GetType(T) Is GetType(String) Then
                Return CType(CType("", Object), T)
            Else
                Return Nothing
            End If
        Else
            Try
                Return r.Field(Of T)(0)
            Catch ex As Exception
                Return CType(r.Item(0), T)
            End Try
        End If
    End Function
