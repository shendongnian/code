    using System;
    using System.Collections.Generic;
    using System.Linq;
					
    public class Program
    {
	    public static void Main()
	    {
		    var data = new List<int>(new int[] { 1, 1, 5, 2, 2 , 7 });
		    var output = data.Select((value, index) => new {value, index})
									.Where(a => data.Count(b => a.value == b) == 1)
									.Select(a => a.index)
									.ToList();
		
		    output.ForEach(o => System.Console.WriteLine(o));
	    }
    }
