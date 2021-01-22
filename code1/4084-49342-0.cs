public static class IntegerExtensions
{
    public static IEnumerable&lt;int&gt; To(this int first, int last)
    {
        for (int i = first; i <= last; i++)      
        { 
            yield return i;
        } 
    }
}
</pre>
