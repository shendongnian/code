      int number = 0;
    int svar = set by the user for exempel 2
    
    do
    {
     
           for (int i = 0; i < svar; i++)
           {
     try
      {
           Console.Write("\nWrite the number you would like to add to your list: ");
           nummer = int.Parse(Console.ReadLine());
       }
    
       catch
       {
       Console.WriteLine("\n-- ERROR --");
       Console.WriteLine("You typed a letter instead of a number, try again!");
       }
    
       myList.Add(number);
    
       }
    
    } while (number == 0);
