    public class ItemBase
    {
    	public virtual string Name { get { return "Base"; } }
    }
    
    public class Hammer : ItemBase
    {
    	public override string Name { get { return "Hammer"; } }
    }
