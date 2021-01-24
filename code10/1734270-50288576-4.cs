    static void Main(string[] args)
    {
    	string str = "P ,B ,B P,P ,T ,P ,P B";
    	string result = string.Empty;
    
    	string[] newChars = str.Split(',').Select(s => s.Trim()).ToArray();
    
    	result = string.Join(" ,", newChars.Select(s => s.Length > 1 ? s.First().ToString() : s)); 
    
    	Console.WriteLine(str);
    	Console.WriteLine(result);
    	Console.ReadLine();
    }
