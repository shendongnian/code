    static void Main(string[] args)
    {
    	string tokens = "1 2 3 |4 5 6 | 7 8";
    	var list = tokens.Split('|');
    
    	list = list.Reverse().Select(n=> n.Trim().PadRight(n.Length,' ')).ToArray();
    
    	for (int i = 0; i < list.Length; i++)
    	{
    	    Console.Write(list[i]);
    	}
    
    	Console.ReadLine();
    }
