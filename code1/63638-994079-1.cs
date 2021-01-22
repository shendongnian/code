    Sub Main()
        Dim xxx As String = "HELLO WORLD"
        Dim yyy As Integer = 42
        Dim zzz As DateTime = DateTime.Now
        DetectName(New With { xxx })
        DetectName(New With { yyy })
        DetectName(New With { zzz })
        ' or...
        ' DetectName(New With { xxx, yyy, zzz })
    End Sub
    Public Sub DetectName(Of T As Class)(test As T)
        Dim piArray As PropertyInfo() = GetType(T).GetProperties()
        Dim pi As PropertyInfo
        For Each pi In piArray
            Dim name As String = pi.Name
            Dim value As Object = pi.GetValue(test, Nothing)
            Dim output As String = _
                "The Value: {0} was stored in the variable named: {1}."
            Debug.WriteLine(String.Format(output, value, name))
        Next
    End Sub
