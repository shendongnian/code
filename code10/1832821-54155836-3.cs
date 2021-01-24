    using System;
    using System.Collections.Generic;
					
    public class Program
    {
	    public static void Main()
	    {
		    var newColl = new List<char>();
            foreach(char c in "aaabbbccc".ToCharArray())
            {
                if (!newColl.Contains(c))
                    newColl.Add(c);
            }
            Console.WriteLine(new string(newColl.ToArray()));
	    }
    }
