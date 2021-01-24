    public abstract class Bar
    {
    	private readonly IBaz _baz;
    	public Bar(IBaz baz)
    	{
    		_baz = baz;
    	}
    	
    	public void DoBaz() => _baz.Baz();
    }
    
    public class BarA : Bar
    {
        //Here I'm passing into the constructor, but you may find it preferable
        //to pass the IBaz directly as a parameter of the DoBaz method
    	public BarA() : base(new BigBaz())
    	{
    	}
    }
