    class User
    {
    	public int MyProperty { get; set; }
    	public int quantity1 { get; set; }
    	public int swgold { get; set; }
    	public int quantity2 { get; set; }
    	public int shgold { get; set; }
    	public double quantity3 { get; set; }
    	public double pgold { get; set; }
    	public bool Leave { get; set; }
    	public void Buy(int input)
    	{
    
    		var Leave = false;
    
    		switch (input)
    		{
    			case (1):
    				Console.WriteLine("How many swords would you like to buy?");
    				quantity1 = Convert.ToInt32(Console.ReadLine());
    				swgold = 5 * quantity1;
    				break;
    
    
    			case (2):
    
    				Console.WriteLine("How many shields would you like to buy?");
    				quantity2 = Convert.ToInt32(Console.ReadLine());
    				shgold = 8 * quantity2;
    				break;
    
    
    			case (3):
    
    				Console.WriteLine("How many potions would you like to buy?");
    				quantity3 = Convert.ToDouble(Console.ReadLine());
    				pgold = 3 * quantity3;
    				break;
    
    			case (4):
    
    				Console.WriteLine($"{quantity1} Swords {swgold} gold");
    				Console.WriteLine($"{quantity2} shields {shgold} gold");
    				Console.WriteLine($"{quantity3} potions {pgold} gold");
    				Console.ReadLine();
    				Leave = true;
    				break;
    		}
    	}
    }
