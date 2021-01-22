    If reader IsNot Nothing Then
        Dim d As New Dictionary(Of String, String)
        Dim enumerator As System.Collections.IDictionaryEnumerator = reader.GetEnumerator()
        While enumerator.MoveNext
            d.Add(enumerator.Key, enumerator.Value)
        End While
        Return d
    End If
