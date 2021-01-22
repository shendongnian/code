vb.net
<Extension()>
Public Sub AddRange(Of T)(ByRef Exttype As IList(Of T), ElementsToAdd As IEnumerable(Of T))
   For Each ele In ElementsToAdd
      Exttype.Add(ele)
   Next
End Sub
And in C#:
c#
public void AddRange<T>(this ref IList<T> Exttype, IEnumerable<T> ElementsToAdd)
{
    foreach (var ele in ElementsToAdd)
    {
        Exttype.Add(ele);
    }
}
