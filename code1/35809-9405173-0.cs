    Public Shared Function ToDataTable(Of T)(data As IList(Of T)) As DataTable
        Dim props As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(T))
        Dim table As New DataTable()
        For i As Integer = 0 To props.Count - 1
                Dim prop As PropertyDescriptor = props(i)
                table.Columns.Add(prop.Name, prop.PropertyType)
        Next
        Dim values As Object() = New Object(props.Count - 1) {}
        For Each item As T In data
                For i As Integer = 0 To values.Length - 1
                        values(i) = props(i).GetValue(item)
                Next
                table.Rows.Add(values)
        Next
        Return table
    End Function
