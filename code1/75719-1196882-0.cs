    bool result = True() | False() && False();
    Console.WriteLine("-----");
    Console.WriteLine(result);
    
    static bool True()
    {
    	Console.WriteLine(true);
    	return true;
    }
    
    static bool False()
    {
    	Console.WriteLine(false);
    	return false;
    }
