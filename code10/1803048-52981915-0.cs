    void Main()
    {
    	dynamic person = new { name = "name" };
    	var age = person.age; // throw when you run the code
        var name = person.name; // I'm cool with it
    
    	object isThisLove;
    	isThisLove.IsReal(); //compiler will throw
    	var isLoveReal = (((Love)isThisLove).IsReal()); // sweet, compiler will ignore, but runtime will throw if love is not Love
    }	
    
    public class Love
    {
    	public bool IsReal() { return false; }
    }
