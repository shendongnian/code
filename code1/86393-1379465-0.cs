    Console.Write("Hello : ");
    for(int k = 0; k <= 100; k++){
    	Console.SetCursorPosition(8, 0);
    	Console.Write("{0}%", k);
    	System.Threading.Thread.Sleep(50);
    }
    
    Console.Read();
