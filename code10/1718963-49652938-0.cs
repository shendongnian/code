    void Main()
    {
    	ItemBase myThing = new Hammer();
    
    	// Doesn't print "Base"
    	Console.WriteLine(myThing.Name);
    
    }
    
    public class ItemBase
    {
    	public virtual string Name { get; } = "Base";
    }
    
    public class Hammer : ItemBase
    {
    	public override string Name { get; } = "Hammer";
    }
