    Public Function MakeReadOnlyFalse(ByVal dt As DataTable) As DataTable
        For Each col As DataColumn In dt.Columns
            If col.ReadOnly Then
                col.ReadOnly = False
            End If
        Next
        Return dt
    End Function
