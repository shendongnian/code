    Public Function SetProperty(ByVal obj As Object, ByVal PropertyName As String, ByVal val As Object) As Boolean
        Dim property_value As Object
        Dim properties_info As System.Reflection.PropertyInfo() = obj.GetType.GetProperties
        Dim property_info As System.Reflection.PropertyInfo
    
        For Each prop As System.Reflection.PropertyInfo In properties_info
            If prop.Name = PropertyName Then property_info = prop
        Next
    
        If property_info IsNot Nothing Then
            Try
                property_info.SetValue(obj, val, Nothing)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Else
            Return False
        End If
    End Function
    
    Public Function GetProperty(ByVal obj As Object, ByVal PropertyName As String) As Object
        Dim property_value As Object
        Dim properties_info As System.Reflection.PropertyInfo() = obj.GetType.GetProperties
        Dim property_info As System.Reflection.PropertyInfo
    
        For Each prop As System.Reflection.PropertyInfo In properties_info
            If prop.Name = PropertyName Then property_info = prop
        Next
    
        If property_info IsNot Nothing Then
            Try
                property_value = property_info.GetValue(obj, Nothing)
                Return property_value
            Catch ex As Exception
                Return Nothing
            End Try
        Else
            Return Nothing
        End If
    End Function
