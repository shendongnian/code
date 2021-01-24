    public static void Sub()
    {
    	Console.WriteLine("Ile liczb chcesz odjąć?");
    	
    	int liczby;
    	while (!int.TryParse(Console.ReadLine(), out liczby))
    		Console.WriteLine("Nie liczba!");
    
    	int[] cyfry = new int[liczby];
    
    	Console.WriteLine("Będziesz odejmować " + liczby + " liczb");
    
    	for (int i = 0; i < liczby; i++)
    	{
    		while (true)
    		{
    			Console.WriteLine("Wpisz " + (i + 1) + " liczbę");
    			
    			if(int.TryParse(Console.ReadLine(), out cyfry[i])) break;
    			
    			Console.WriteLine("Nie liczba!");
    		}
    	}
    
    	int wynik = cyfry[0];
    	
    	for (int i = 1; i < liczby; i++)
    		wynik -= cyfry[i];
    	
    	Console.WriteLine("Wynik to " + wynik);
    }
