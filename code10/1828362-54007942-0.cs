    void Main()
    {
    	Console.WriteLine("Please enter the number of strings you would like to enter: ");
    	Console.Write("> ");
    	var number_of_strings = Int32.Parse(Console.ReadLine());
    	var strings = new string[number_of_strings];
    	for (int i = 0; i < number_of_strings; i++)
    	{
    		Console.WriteLine($"Please enter the {AddOrdinal(i+1)} string");
    		strings[i] = Console.ReadLine();
    	}
    	var str = string.Join("", strings);
    	var strSorted = string.Concat(str.OrderBy(x=>x));
    	Console.WriteLine(strSorted);
    }
    
    public static string AddOrdinal(int num)
    {
    	if (num <= 0) return num.ToString();
    
    	switch (num % 100)
    	{
    		case 11:
    		case 12:
    		case 13:
    			return num + "th";
    	}
    
    	switch (num % 10)
    	{
    		case 1:
    			return num + "st";
    		case 2:
    			return num + "nd";
    		case 3:
    			return num + "rd";
    		default:
    			return num + "th";
    	}
    
    }
