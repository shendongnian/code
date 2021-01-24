    public abstract class BaseNode
    {
    	public IList<BaseNode> Children
    	{ get; } = new List<BaseNode>();
    }
    public class NodeClassA : BaseNode { }
    public class NodeClassB : BaseNode { }
    public class NodeClassC : BaseNode { }
