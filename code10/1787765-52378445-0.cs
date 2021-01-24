    using System;
    using System.Linq;
    using System.Collections.Generic;
					
    public class Program
    {
	    public static void Main()
	    {
		    List<string> list = System.Enum.GetValues(typeof(Status))
			    .Cast<Status>()
			    .Select(x => x.ToString())
			    .ToList();
		
		    list.ForEach(Console.WriteLine);
	    }
    }
    public enum Status
    {
        Enable,
        Disable
    }
