    static void Main(string[] args)
    {
    	List<string> myList = new List<string>();
    
    	for(int i = 0; i < 500000; i++)
    	{
    		myList.Add(i.ToString());
    	}
    
    	DateTime start = DateTime.Now;
    	foreach(string s in myList)
    	{
    		Console.WriteLine(s);
    	}
    	DateTime end = DateTime.Now;
    
    	Console.WriteLine(end - start);
    	Console.ReadLine();
    }
