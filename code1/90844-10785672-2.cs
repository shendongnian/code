    Public Shared Function DataReaderMapToList(Of T)(ByVal dr As IDataReader) As List(Of T)
            Dim list As New List(Of T)
            Dim obj As T
            While dr.Read()
                obj = Activator.CreateInstance(Of T)()
                For Each prop As PropertyInfo In obj.GetType().GetProperties()
                    If Not Object.Equals(dr(prop.Name), DBNull.Value) Then
                        prop.SetValue(obj, dr(prop.Name), Nothing)
                    End If
                Next
                list.Add(obj)
            End While
            Return list
        End Function
