    public sealed class Example
    {
        private string field = "secure";
    
        private void PrintField()
        {
            Console.WriteLine(this.field);
        }
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		var example = new Example();
    		var field = example.GetType().GetField("field", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    		var method = example.GetType().GetMethod("PrintField", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    
    		field.SetValue(example, "hacked");
    		method.Invoke(example, new object[] { });
    		Console.ReadLine();
    	}
    }
