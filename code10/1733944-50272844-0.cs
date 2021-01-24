    public static void Main()
    {
    	string test = "_+ù$é";   //change this to any 
    	Regex regex = new Regex(@"[a-z]");
        Match match = regex.Match(test);
    
        if (match.Success)
        {
          Console.WriteLine("Matched");
        }
    	else
          Console.WriteLine("Not Matched");
    		
    }
