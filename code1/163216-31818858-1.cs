    Public Class Res
        Private Shared __keys As New List(Of String)
        Shared Function Exist(partName As String) As Boolean
            Dim r As Boolean = False
            If __keys.Count < 1 Then
                Dim a = Assembly.GetExecutingAssembly()
                Dim resourceName = a.GetName().Name + ".g"
                Dim resourceManager = New ResourceManager(resourceName, a)
                Dim resourceSet = resourceManager.GetResourceSet(Globalization.CultureInfo.CurrentCulture, True, True)
                For Each res As System.Collections.DictionaryEntry In resourceSet
                    __keys.Add(res.Key)
                Next
            End If
            __keys.ForEach(Sub(e)
                               If e.Contains(partName.ToLower) Then
                                   r = True
                                   Exit Sub
                               End If
                           End Sub)
            Return r
        End Function
    End Class
