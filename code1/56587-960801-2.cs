    <System.Runtime.CompilerServices.Extension()> _
        Public Function GetPropertyValue(Of ValueType)(ByVal Source As Object, ByVal PropertyName As String) As ValueType
            Dim pInfo As System.Reflection.PropertyInfo
            pInfo = Source.GetType.GetProperty(PropertyName)
            If pInfo Is Nothing Then
                Throw New Exception("Property " & PropertyName & " does not exists for object of type " & Source.GetType.Name)
            Else
                Return pInfo.GetValue(Source, Nothing)
            End If
        End Function
        <System.Runtime.CompilerServices.Extension()> _
        Public Function GetPropertyType(ByVal Source As Object, ByVal PropertyName As String) As Type
            Dim pInfo As System.Reflection.PropertyInfo
            pInfo = Source.GetType.GetProperty(PropertyName)
            If pInfo Is Nothing Then
                Throw New Exception("Property " & PropertyName & " does not exists for object of type " & Source.GetType.Name)
            Else
                Return pInfo.PropertyType
            End If
        End Function
