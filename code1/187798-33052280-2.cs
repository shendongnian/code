    System.Type.GetType("Namespace Name" + "." + "Class Name" + "+" + "Enum Name")
    
    Dim fieldInfos() As System.Reflection.FieldInfo = System.Type.GetType("YourNameSpaceName.TestClass+TestEnum").GetFields
    
    For Each f As System.Reflection.FieldInfo In fieldInfos 
        If f.IsLiteral Then 
            MsgBox(f.Name & " : " & CType(f.GetValue(Nothing), Integer) & vbCrLf) 
        End If 
    Next 
    
    Public Class TestClass
        Public Enum TestEnum
            val1 = 20
            val2 = 30
        End Enum
    End Class
