class SpecialMap&lt;TKey, TValue&gt; : IDictionary&lt;TKey, TValue&gt; { ... }
public class Widget
{
    private SpecialMap&lt;string, string&gt; map = new SpecialMap&lt;string, string&gt;();
    public IDictionary&lt;string, string&gt; Map
    {
        get { return map; }
    }
}
