    Public Shared Function ConvertToTypedDataTable(Of T As {Data.DataTable, New})(dtBase As Data.DataTable) As T
        Dim dtTyped As New T
        dtTyped.Merge(dtBase)
        Return dtTyped
    End Function
