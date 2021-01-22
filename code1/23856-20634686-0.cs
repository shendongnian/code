        Public Module Extensions
            <Extension()>
            Public Function HasColumn(r As SqlDataReader, columnName As String) As Boolean
                Return If(String.IsNullOrEmpty(columnName) OrElse r.FieldCount = 0, False, Enumerable.Range(0, r.FieldCount).Select(Function(i) r.GetName(i)).Contains(columnName, StringComparer.OrdinalIgnoreCase))
            End Function
        End Module
