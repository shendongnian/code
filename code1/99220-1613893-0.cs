public static class IEnumeratorExtensions
{
    public static IEnumerator&lt;T&gt; GetEnumerator&lt;T&gt;(this IEnumerable&lt;T&gt; ie,
        T[] val1, T[] val2)
    {
        //your code here
    }
}
...
string[] s1;
string[] s2;
var qry = from s in new string[]{"1", "2"}
          select s;
qry.GetEnumerator(s1, s2);
...
