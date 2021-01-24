    static void Main(string[] args)
    {
    	List<Data> list = new List<Data>();
    
    	var dd = File.ReadAllLines(@"C:\Users\XXXX\Desktop\test.txt")
    	 .Skip(1)
    	 .Where(s => s.Length > 1).ToList();
    
    	foreach (var item in dd)
    	{
    		var columns = item.Split('\t').Where(c => c.Trim() != string.Empty).ToList();
    
    		if (columns != null && columns.Count > 0)
    		{
    			int id;
    
    			if (int.TryParse(columns[0], out id))
    			{
    				list.Add(new Data()
    				{
    					id = Convert.ToInt32(columns[0]),
    					Name = columns[1],
    					Description = columns[2],
    					Quantity = Convert.ToInt32(columns[3]),
    					Rate = Convert.ToDouble(columns[4]),
    					Discount = Convert.ToInt32(columns[5]),
    					Amount = int.Parse(columns[6])
    				});
    			}
    			else
    			{
    				list.Last().Description += columns[0];
    			}
    		}
    	}
    
    	Console.ReadLine();
    }
