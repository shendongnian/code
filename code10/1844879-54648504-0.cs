    using System;
    using System.Text;
					
    public class Program
    {
	public static void Main()
	{
		   StringBuilder options = new StringBuilder();
		Food model= new Food();
		
        if (model.Fruits.HasValue)
        {
            options.Append("FR,");
        }
        if (model.Drinks.HasValue)
        {
			options.Append("DR,");
        }
        if (model.Lunch.HasValue)
        {
			
            options.Append("LU,");
        }
        if (model.Dinner.HasValue)
        {
            options.Append("DI,");
        }
		Console.WriteLine(options);
	}
    }
    public class Food{
	public int? Fruits{get;set;}
	public int? Drinks{get;set;}
	public int? Lunch{get;set;}
	public int? Dinner{get;set;}
	
	public Food(){
		Fruits=1;
		Drinks=null;
		Lunch=2;
		Dinner=3;
	}
	
    }
