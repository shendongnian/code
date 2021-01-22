    Public Function ConvertArrayToDatatable(ByVal arrList As ArrayList) As DataTable
                Dim dt As New DataTable
                Try
                    If arrList.Count > 0 Then
                        Dim arrype As Type = arrList(0).GetType()
                        dt = New DataTable(arrype.Name)
    
                        For Each propInfo As PropertyInfo In arrype.GetProperties()
                            dt.Columns.Add(New DataColumn(propInfo.Name))
                        Next
    
                        For Each obj As Object In arrList
                            Dim dr As DataRow = dt.NewRow()
    
                            For Each dc As DataColumn In dt.Columns
                                dr(dc.ColumnName) = obj.GetType().GetProperty(dc.ColumnName).GetValue(obj, Nothing)
                            Next
                            dt.Rows.Add(dr)
    
                        Next
                    End If
    
                  
                    Return dt
                Catch ex As Exception
                    Return dt
                End Try
    
            End Function
