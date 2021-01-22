    public abstract class Foo
    {
    	protected Foo() {
    		Console.WriteLine ("Foo");
    	}
    }
    
    public class Bar : Foo
    {
    	public Bar() {
    		Console.WriteLine ("Bar");
    	}
    }
    
    void Main()
    {
    	new Bar();
    }
