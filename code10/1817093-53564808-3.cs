    static void Main(string[] args)
    {
    	Console.WriteLine("Daniel Nosek");
    	Console.WriteLine("Výpočet obvodu a obsahu - trojúhelník, pravidelný šestiúhelník");
    	Console.WriteLine("Zvolte si obrazec:");
    	Console.WriteLine("1 - trojúhelník");
    	Console.WriteLine("2 - pravidelný šestiúhelník");
    
    	int VolbaObrazce = int.Parse(Console.ReadLine());
    	double obvod = 0;
    	double obsah = 0;
    	
    	bool recalculate = false;
    	
    	do
    	{
            Console.Clear();
    		switch (VolbaObrazce)
    		{
    			case 1:
    				double a = ReadInVariable("Zadejte délku strany a:");
    				double b = ReadInVariable("Zadejte délku strany b:");
    				double c = ReadInVariable("Zadejte délku strany c:");
    
    				obvod = ObvodTrojuhelniku(a, b, c);
    				obsah = ObsahTrojuhelniku(a, b, c);
    				break;
    
    			case 2:
    				double d = ReadInVariable("Zadejte délku strany d:");
    
    				obvod = ObvodSestiuhelniku(d);
    				obsah = ObsahSestiuhelniku(d);
    				break;
    			default:
    				return;
    		}
    
    		// Output your results
    		Console.WriteLine("obvod: " + Math.Round(obvod, 2)); // this will round to 2 digits after the .
    		Console.WriteLine("obsah: " + Math.Round(obsah, 2));
    		
    		// check if the read in variable is equal to 1 and write that (true or false)
    		// into the variable 'recalculate'
    		recalculate = ReadInVariable("If you want to recalculate, enter 1:") == 1;
    	}
    	while(recalculate);
    }
    
    static double ReadInVariable(string text)
    {
    	Console.Write(text);
    	return double.Parse(Console.ReadLine());
    }
    
    static double ObvodTrojuhelniku(double a, double b, double c) // vypocet obvodu pomoci souctu stran
    {
    	return a + b + c;
    }
    
    static double ObsahTrojuhelniku(double a, double b, double c) // obsah pomoci heronova vzorce
    {
    	double s = (a + b + c) / 2;
    	return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }
    
    static double ObvodSestiuhelniku(double d) // obvod sestiuhelniku
    {
    	return 6 * d;
    }
    
    static double ObsahSestiuhelniku(double d) // obsah sestiuhelniku
    {
    	return ((3 * Math.Sqrt(3) * Math.Pow(d, 2))) / 2;
    }
