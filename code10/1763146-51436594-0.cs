    static void Main(string[] args)
    {
    	string numbers = "1234567890";
    
    	Console.WriteLine(string.Join(",", CustomSplit(numbers, 1)));
    	Console.WriteLine(string.Join(",", CustomSplit(numbers, 2)));
    	Console.WriteLine(string.Join(",", CustomSplit(numbers, 3)));
    
    	Console.ReadLine();
    }
    
    public static List<string> CustomSplit(string Input, int Length)
    {
    	List<string> result = new List<string>();
    
    
    	string[] split = new string[Input.Length / Length + (Input.Length % Length == 0 ? 0 : 1)];
    
    	for (int i = 0; i < split.Length; i++)
    	{
    	result.Add( Input.Substring(i * Length, i * Length + Length > Input.Length ? 1 : Length));
    	}
    
    	return result;
    }
