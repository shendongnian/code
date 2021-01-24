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
    	switch (VolbaObrazce)
    	{
    		case 1:
    			Console.WriteLine("Zadejte délku strany a:");
    			double a = double.Parse(Console.ReadLine());
    			Console.WriteLine("Zadejte délku strany b:");
    			double b = double.Parse(Console.ReadLine());
    			Console.WriteLine("Zadejte délku strany c:");
    			double c = double.Parse(Console.ReadLine());
    
    			obvod = ObvodTrojuhelniku(a, b, c);
    			obsah = ObsahTrojuhelniku(a, b, c);
    			break;
    
    		case 2:
    			Console.WriteLine("Zadejte délku strany d:");
    			double d = double.Parse(Console.ReadLine());
    
    			obvod = ObvodSestiuhelniku(d);
    			obsah = ObsahSestiuhelniku(d);
    			break;
    	}
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
