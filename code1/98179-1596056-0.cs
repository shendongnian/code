public class Widget
{
    private Dictionary&lt;string, string&gt; map = new Dictionary&lt;string, string&gt;();
    public IDictionary&lt;string, string&gt; Map
    {
        get { return map; }
    }
}
