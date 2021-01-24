	public class Program
	{
	    static void Main(string[] args)
	    {
	        var VariableParameter1_On = false;
	        var address = new Address { Name = "Adam", City = "Paris" };
	        
	        if (VariableParameter1_On)
	            address.Parameter1 = "Test";
	        
	        Console.ReadKey();
	    }
	}
