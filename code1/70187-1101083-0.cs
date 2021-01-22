internal sealed class MagicBeanListDebugView
{
    private List&lt;MagicBean&gt; list;
    public MagicBeanListDebugView(List&lt;MagicBean&gt; list)
    {
        this.list = list;
    }
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public MagicBean[] Items{get {return list.ToArray();}}
}
You can then declare this class to be used by the debugger for displaying your class, along with the DebuggerDisplay attribute:
[DebuggerDisplay("Count = {Count}")]
[DebuggerTypeProxy(typeof(MagicBeanListDebugView))]
public class MagicBeanList : List&lt;MagicBean&gt;
{}
