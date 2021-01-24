	public interface IBazzer
	{
	    void Baz();
	}
	
	public class TheBaz : IBazzer
	{
		public void Baz()
		{
			Console.WriteLine("Hello World");
		}
	}
	public class Wrapper : IBazzer
	{
	    private IBazzer _instance;
	
	    public Wrapper(IBazzer instance)
	    {
	        _instance = instance;
	    }
	
	    public void Baz()
	    {
            // do stuff before calling the wrapped Bazzer
            this.PreBaz();
	        _instance.Baz();
            // do stuff after calling the wrapped Bazzer	    
            this.PostBaz();
        }
        
        protected virtual void PreBaz(){}
        protected virtual void PostBaz(){}
	}
	
    public class FooWrapper : Wrapper
	{
		public FooWrapper(IBazzer wrapped):base(wrapped){}
        protected override void PreBaz()
        {
            Console.WriteLine("Foo Pre Baz");
        }
        protected override void PostBaz()
        {
            Console.WriteLine("Foo Post Baz");
        }
        
	}
	
	public class BarWrapper : Wrapper
	{
		public BarWrapper(IBazzer wrapped):base(wrapped){}
        protected override void PreBaz()
        {
            Console.WriteLine("Bar Pre Baz");
        }
        protected override void PostBaz()
        {
            Console.WriteLine("Bar Post Baz");
        }
	}
    void Main()
    {
        var x = new 	TheBaz();
        var y = new FooWrapper(x);
        y.Baz(); 
        // Foo Pre Baz
        // Hello World
        // Foo Post Baz
    }
