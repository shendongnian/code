    public static void Main()
    {
    		string[] separator = { ", ", "; " };
            string names = "Peter, John; Andy, David";
            string[] substrings = names.Split(separator, StringSplitOptions.None);
    
            foreach(var name in substrings)
    		{
    			Console.WriteLine(name);
    		}
    		
    }
