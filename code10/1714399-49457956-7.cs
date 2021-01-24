     //Don't do this
     while (true)
     {
         try
         {
             int fahrenheit = int.Parse(Console.ReadLine());
             break;
         }
         catch (FormatException ex)
         {
             Console.WriteLine("Nummer nicht gut!!!")
         }
    }
