    public static void Main()
    	{
    		
    		Console.WriteLine("Start Work ...\r\n");
    		
    		Create_list();
    		
    		Sort_list();
    		
    		Console.WriteLine("\r\nFinish.");
    		
    	}
    	
    	private static List<custom_item> List_unsort = new List<custom_item>();
    	
    	private class custom_item
    	{
    		public int id { get; set; }
    		
    		public string name { get; set; }
    		
    		public double number { get; set; }
    	}
    	
    	
    	private static void Create_list()
    	{
    		Random rnd = new Random();
    		Console.WriteLine("Unsort List : ");
    		for (int i = 0; i < 10; i++)
    		{
    			custom_item item = new custom_item();
    			item.name = i.ToString();
    			item.id = i;
    			
    			double rnd_num = rnd.NextDouble();
    			item.number = rnd_num;
    			
    			Console.WriteLine("ID : " + item.id + ", number : " + item.number);
    			List_unsort.Add(item);
    		}
    		Console.WriteLine("\r\n--------------------\r\n");
    	}
    	
    	private static void Sort_list()
    	{
    		var list = List_unsort.OrderBy(x => x.number);
    		Console.WriteLine("Sort List : ");
    		foreach (var item in list)
    		{
    			Console.WriteLine("ID : " + item.id + ", number : " + item.number);
    		}
    	}
