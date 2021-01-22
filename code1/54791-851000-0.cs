    void Main()
    {
        int n = 100;
        
        string[] a = {"q2", "q3", "b"};
        a = a.Concat(Enumerable.Repeat(0,n).Select(i => "qasd")).ToArray(); /* Random data */
	
        /* Regex Method */
        System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("^q[0-9]+$");
        List<string> regMethod = a.Where(c => r.IsMatch(c)).ToList().Dump("Result");
        /* IsInteger Method */
        List<string> intMethod = a.Where(c => c.StartsWith("q") && IsInteger(c.Substring(1))).ToList().Dump("Result");
    }
    public static bool IsInteger(string theValue)
    {
       try
       {
           Convert.ToInt32(theValue);
           return true;
       } 
       catch 
       {
           return false;
       }
    }
