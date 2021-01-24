    public static void Main()
    	{
    		string s;
            string sReverse = string.Empty;   // Initialise (always recommended)
    
            Console.WriteLine("Say any word please: ");
            s = Console.ReadLine();
    
            for (int i = s.Length-1; i >=0 ; i--)  // Chnage the order of indexing
            {
    			sReverse += s[i];   // make new string everytime since strings are immutable.
            }
    		Console.WriteLine(sReverse);  // print your new string
    	}
