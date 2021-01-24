    public interface IBaz
    {
    	void Baz();
    }
    
    public class BigBaz : IBaz
    {
    	public void Baz() => Console.WriteLine("Big Baz!");
    }
