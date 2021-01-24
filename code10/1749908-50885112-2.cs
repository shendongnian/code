    void Main()
    {
        while (!TryParseIntegerArray(Console.ReadLine(), out var arr))
    	{
    		Console.WriteLine("Please Enter a valid integer or comma-separated string!");	
    	}
        // work with arr here
    }
    bool TryParseIntegerArray(string input, out int[] arr)
    {
    	if (input == null)
    		throw new ArgumentNullException(nameof(input));
    
        try
        {
            arr = input.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToArray();
    		return true;
        }
        catch (FormatException)
        {
            arr = null;
    		return false;
        }
    }
