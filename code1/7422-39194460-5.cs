    public class Program
    {
    	public static void Main()
    	{
    		var child = new Child();
    		// anything that is done on parent virtual member is destroyed
    		Console.WriteLine(child.Obj);
    		// Output: "Something"
    	}
    } 
