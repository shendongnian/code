    Imports System.Reflection
    ''' <summary>
    ''' Convert any List(Of T) to a DataTable with correct column types and converts Nullable Type values to DBNull
    ''' </summary>
    
    Public Class ConvertListToDataset
        
        Public Function ListToDataset(Of T)(ByVal list As IList(Of T)) As DataTable
        
            Dim dt As New DataTable()
            '/* Create the DataTable columns */
            For Each pi As PropertyInfo In GetType(T).GetProperties()
                If pi.PropertyType.IsValueType Then
                    Debug.Print(pi.Name)
                End If
                If IsNothing(Nullable.GetUnderlyingType(pi.PropertyType)) Then
                    dt.Columns.Add(pi.Name, pi.PropertyType)
                Else
                    dt.Columns.Add(pi.Name, Nullable.GetUnderlyingType(pi.PropertyType))
                End If
            Next
        
            '/* Populate the DataTable with the values in the Items in List */
            For Each item As T In list
                Dim dr As DataRow = dt.NewRow()
                For Each pi As PropertyInfo In GetType(T).GetProperties()
                    dr(pi.Name) = IIf(IsNothing(pi.GetValue(item)), DBNull.Value, pi.GetValue(item))
                Next
                dt.Rows.Add(dr)
            Next
            Return dt
        
        End Function
        
    End Class
