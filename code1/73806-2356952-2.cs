    using System;
    public class InternalTesting
    {
    public static void Main(string[] args)
    {
      bool jumping = false;
        try
        {
            if (DateTime.Now < DateTime.MaxValue)
            {
                jumping = (Environment.NewLine != "\t");
                goto ILikeCheese;
            }
    	else{
            	return;
    	}
        }
        finally
        {
            if (jumping)
    {
                //throw new InvalidOperationException("You only have cottage cheese.");
    	Console.WriteLine("Test Me Deeply");
    }
        }
    ILikeCheese:
        Console.WriteLine("MMM. Cheese is yummy.");
    }
    }
