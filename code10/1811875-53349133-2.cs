    using System;
    using System.Text;	// Add this for StringBuilder				
    public class Program
    {
    	public static void Main()
    	{
    		string s;
            StringBuilder sReverse = new StringBuilder();  // Instantiate the object.
    
            Console.WriteLine("Say any word please: ");
            s = Console.ReadLine();
            
            for (int i = s.Length-1; i >=0 ; i--)
            {
    			sReverse.Append(s[i]);  // Keep Appending to original string.
            }
    		Console.WriteLine(sReverse.ToString());  // finally convert to printable string.
    	}
    }
