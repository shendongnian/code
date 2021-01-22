    static void Main(string[] args)
    {
    	List<string> myList = new List<string>();
    
    	for(int i = 0; i < 500000; i++)
    	{
    		myList.Add(i.ToString());
    	}
    
    	DateTime st = DateTime.Now;
    	foreach(string s in myList)
    	{
    		Console.WriteLine(s);
    	}
    	DateTime et = DateTime.Now;
    
    	Console.WriteLine(et - st);
    	Console.ReadLine();
    }
