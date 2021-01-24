    class CutomSort
    	{
    		class Color
    		{
    			public int Id;
    			public string Name;
    		}
    
    		static void Main(string[] args)
    		{
    			Color[] input = {
    								new Color{Id=4, Name="Green"},
    								new Color{Id=3, Name="Yellow"},
    								new Color{ Id=1, Name="Red"},
    								new Color{ Id = 2, Name = "Blue" }
    							};
    
    			IEnumerable<Color> result = input.OrderBy(x => x.Id);
    
    			foreach (Color color in result)
    			{
    				Console.WriteLine($"{color.Id}-{color.Name}");
    			}
    
    			Console.ReadKey();
    		}
    	}
