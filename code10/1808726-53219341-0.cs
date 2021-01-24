    enum Color : long
    {
    	red = 1,
    	black = 2,
    	blue = 3,   
    	ALL = 255
    }				
    public class Program
    {
        public static void Main()
    	{
    		var result = Enum.GetValues(typeof(Color)).Cast<long>().Max();
    		Console.WriteLine(result);
    	}
    }
