    class Program
    {
    	public class ObjectNameComparer : IComparer<object>
    	{
    		public int Compare(object x, object y)
    		{
    			var n1 = x.ToString().Split('_');
    			var n2 = y.ToString().Split('_');
    			var nameCompare = string.Compare(n1[0], n2[0], StringComparison.OrdinalIgnoreCase);
    			if (nameCompare == 0)
    			{
    				var i1 = int.Parse(n1[1]);
    				var i2 = int.Parse(n2[1]);
    				if (i1 == i2)
    				{
    					var i12 = int.Parse(n1[2]);
    					var i22 = int.Parse(n2[2]);
    					return i12 - i22;
    				}
    				return i1 - i2;
    			}
    			return nameCompare;
    		}
    	}
    
    	static void Main(string[] args)
    	{
    		var objectList = new List<object>();
    
    		objectList.AddRange(new object[]
    			{
    				"mapPart_1_0",
    				"mapPart_1_10",
    				"mapPart_100_10",
    				"mapPart_1_12",
    				"mapPart_22_11",
    				"mapPart_1_24",
    				"mapPart_2_1",
    				"mapPart_10_24",
    				"mapPart_2_11",
    			});
    
    		var ordered = objectList.OrderBy(a => a, new ObjectNameComparer());
    		
    	}
    }
