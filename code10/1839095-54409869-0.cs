    using System;
    using System.Linq;
					
    public class Program
    {
    	public static void Main()
    	{
    		var response = new [] {
    			new { Id = 1, Name = "Peter", Value = 1, Status = "New" },
    			new { Id = 1, Name = "Peter", Value = 1, Status = "Old" },
    			new { Id = 1, Name = "Peter", Value = 1, Status = "Pending" },
    			new { Id = 2, Name = "Peter", Value = 1, Status = "New" },
    			new { Id = 2, Name = "Sandy", Value = 2, Status = "Old" }
    		};
    		var result = response
                     .GroupBy(o => new { o.Id, o.Name, o.Value })
                     .Where(g => g.Count() > 1)
                     .Select(y => y.Key)
                     .ToList();
    		
    		Console.WriteLine(string.Join(Environment.NewLine, result));
    	}
    }
