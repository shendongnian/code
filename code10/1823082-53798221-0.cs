    using System;
	
    public class Program
    {
	    public static void Main()
	    {
		    string  a =  "Stuff, another thing, random stuff, snuff, Pigs are wierd, sick, Cats are dangerous, they will kill you, Cows produce milk, but horses don't";
		    string[] splittedStrings = a.Split(new[]{", "}, StringSplitOptions.None);
		    for (var i = 0; i < splittedStrings.Length / 2; i++)
		    {
			    Console.WriteLine(splittedStrings[i*2] + ", " + splittedStrings[i*2 + 1]);
		    }
		    if(splittedStrings.Length % 2 == 1)
		    {
			    Console.WriteLine(splittedStrings[splittedStrings.Length-1]);
		    }
	    }
    }
