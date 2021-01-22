    Imports System.Runtime.CompilerServices
    Imports System.Reflection
    
    Module Extensions
    
        <Extension()>
        Public Function ToDataTable(Of T)(ByVal collection As IEnumerable(Of T)) As DataTable
            Dim dt As DataTable = New DataTable("DataTable")
            Dim type As Type = GetType(T)
            Dim pia() As PropertyInfo = type.GetProperties()
    
            ' For a collection of primitive types create a 1 column DataTable
            If type.IsPrimitive OrElse type.Equals(GetType(String)) Then
                dt.Columns.Add("Column", type)
            Else
                ' Inspect the properties and create the column in the DataTable
                For Each pi As PropertyInfo In pia
                    Dim ColumnType As Type = pi.PropertyType
                    If ColumnType.IsGenericType Then
                        ColumnType = ColumnType.GetGenericArguments()(0)
                    End If
                    dt.Columns.Add(pi.Name, ColumnType)
                Next
    
            End If
    
            ' Populate the data table
            For Each item As T In collection
                Dim dr As DataRow = dt.NewRow()
                dr.BeginEdit()
                ' Set item as the value for the lone column on each row
                If type.IsPrimitive OrElse type.Equals(GetType(String)) Then
                    dr("Column") = item
                Else
                    For Each pi As PropertyInfo In pia
                        If pi.GetValue(item, Nothing) <> Nothing Then
                            dr(pi.Name) = pi.GetValue(item, Nothing)
                        End If
                    Next
                End If
                dr.EndEdit()
                dt.Rows.Add(dr)
            Next
            Return dt
        End Function
    
    End Module
