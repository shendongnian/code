    public interface INodeChild
    {
    	public INodeParent Parent {get;set;}
    	//Any methods/properties common to ALL inheritors
    }
    
    public abstract class NodeParent : INodeChild
    {
    	public INodeParent Parent {get; protected set;}
    
    	public IList<INodeChild> Children {get;set;}
    	// This is just breadth-wise since I'm more familiar with that.
    	public string ListChildren(int level)
    	{
    		StringBuilder sb = new StringBuilder();
    		foreach(INodeChild item in Children)
    		{
    			sb.AppendLine(Enumerable.Repeat(" ", level));
    			INodeParent itemParent = item as INodeParent;
    			if(itemParent != null)
    			{
    				itemParent.ListChildren(++level);
    			}
    		}
    		return sb.ToString();
    	}
    	//Any methods/properties common to all parent inheritors (brach/twig/etc)
    }
    
    public class Brach : NodeParent
    {
    	// Any branch only stuff goes here.
    }
    
    public class Twig : NodeParent
    {
    	// Any twig only stuff goes here
    }
    
    public class Leaf : INodeChild
    {
    	// Any leaf only stuff goes here.
    }
