      Public Shared Function IsPersistable(Type As System.Type) As Boolean
        With TypeInformation.UnderlyingType(Type)
          Return .IsValueType OrElse Type = GetType(String) OrElse .IsPrimitive
        End With
      End Function
    
      Public Shared Function IsNullable(ByVal Type As System.Type) As Boolean
        Return (Type.IsGenericType) AndAlso (Type.GetGenericTypeDefinition() Is GetType(Nullable(Of )))
      End Function
    
      Public Shared Function UnderlyingType(ByVal Type As System.Type) As System.Type
        If IsNullable(Type) Then
          Return Nullable.GetUnderlyingType(Type)
        Else
          Return Type
        End If
      End Function
