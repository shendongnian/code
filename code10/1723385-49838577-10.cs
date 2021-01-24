    public class MyStack<T> : System.Collections.Stack : where T : LogicalTreeNode
    {
    	public void TryPush(LogicalTreeNode logicalTreeNode)
    	{
    		/*Some logic */
    		this.TryPush(new ConditionResult(false));
    	}
    }
