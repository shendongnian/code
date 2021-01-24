    public abstract class Group
    {
    	public Group ParentGroup { get; set; }
    	public abstract void Accept(GroupVisitor visitor);
    }
