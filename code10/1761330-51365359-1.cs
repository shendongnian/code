	var context = new Context();
	
	NameOf(context, x => x.Inner.Inner.Value).Dump(); // Inner.Inner.Value
	NameOf(() => context.Inner.Inner.Value).Dump(); // context.Inner.Inner.Value
    public class Context
    {
    	public Context Inner => this;
    	public int Value => 1;
    }
