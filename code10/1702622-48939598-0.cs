    using System;
    
    // Implement your classes here.
    public abstract class Astrodroid
    {
    	public virtual string GetSound()
        { 
            return "Beep beep";
        }
    	public void MakeSound()
		{
			Console.WriteLine(GetSound());
		}
    }
    
     
    public class R2 : Astrodroid
    {
    	public override string GetSound()
        {
            return "Beep bop";
        }
    }
    
    public class Program
    {
    	public static void Main()
    	{
            
    	}
    }
