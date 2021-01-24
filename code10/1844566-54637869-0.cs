     Console.WriteLine("Geef prijs:");
        
      if(double.TryParse(Console.ReadLine(), out double invoer))
	  {
			
	   double metBTW = invoer * BTW;
       Console.WriteLine($"De prijs is : {invoer} , de btw is : {BTW} , otaalprijs is : {metBTW}");
       Console.ReadKey();
				
    }
    else 
    {
	  Console.WriteLine("Bad input");
    }
