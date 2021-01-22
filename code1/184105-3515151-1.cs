    static void Main(string[] args)
    {
    	StringMe sm = new StringMe();
    	object inVar = "world!";
    	string returnVar = sm.AddString(ref inVar).ToString();
    	System.Console.WriteLine(returnVar);
    }
