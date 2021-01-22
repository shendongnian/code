    Public Shared Function GetCombinationsFromIEnumerables(ByRef chain() As Object, ByRef IEnumerables As IEnumerable(Of IEnumerable(Of Object))) As List(Of Object())
        Dim Combinations As New List(Of Object())
        If IEnumerables.Any Then
            For Each v In IEnumerables.First
                Combinations.AddRange(GetCombinationsFromIEnumerables(chain.Concat(New Object() {v}).ToArray, IEnumerables.Skip(1)).ToArray)
            Next
        Else
            Combinations.Add(chain)
        End If
        Return Combinations
    End Function
    Public Shared Function GetCombinationsFromIEnumerables(ByVal ParamArray IEnumerables() As IEnumerable(Of Object)) As List(Of Object())
        Return GetCombinationsFromIEnumerables(chain:=New Object() {}, IEnumerables:=IEnumerables.AsEnumerable)
    End Function
