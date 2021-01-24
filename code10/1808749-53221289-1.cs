    void Main()
    {
    	double[] ICE = new double[8];
    	
    	double userInput = 0.0;
    
    	for (int counter = 0; counter < ICE.Length; counter++)
    	{
    		Console.WriteLine($"Please enter your mark for ICE {counter}: ");
    		
    		bool isNumerical = false;
    		
    		while(!isNumerical)
    			isNumerical = double.TryParse(Console.ReadLine(), out userInput);
    		
    		ICE[counter] = userInput;
    	}
    
    	Console.WriteLine("Average : " + ICE.Average());
    	Console.ReadLine();
    }
