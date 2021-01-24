    void Main()
    {
    	Console.WriteLine(GetMinX(1, 2, 3));
        Console.WriteLine(GetMinX(0, 3, 2));
        Console.WriteLine(GetMinX(1, -2, -3));
        Console.WriteLine(GetMinX(5, 2, 1));
        Console.WriteLine(GetMinX(4, 3, 2));
        Console.WriteLine(GetMinX(0, 4, 5));
    
    	// in these cases the solution exists:
    	Console.WriteLine(GetMinX(0, 0, 2) != "Impossible");
    	Console.WriteLine(GetMinX(0, 0, 0) != "Impossible");
    }
    
    private static string GetMinX(int a, int b, int c)
    {
         //We can't proceed if a is zero otherwise we will get division by zero error
         if(a == 0)
            return "Invalid"; //Exit method with message. I would inform about mistake like "a variable is equal to zero"
         //Per requirement check if a or b or c is non negative - we can't do calculations then
         if(a < 0 || b < 0 || c < 0)
            return "Impossible"; //Exit method with message. Again I would use more informative message
    
    	//all good do calculation and return result
    	var minX = (double)(-b / ((2.0) * a));
    	return minX.ToString();
    }
