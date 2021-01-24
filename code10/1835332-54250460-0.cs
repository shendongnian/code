     for (int i = 0; i < svar; i++)
     {
         Console.Write("\nWrite the number you would like to add to your list: ");
         while (!int.TryParse(Console.ReadLine(), out number))
         {
             Console.WriteLine("\n-- ERROR --");
             Console.WriteLine("You typed a letter instead of a number, try again!");
         }
         myList.Add(number);
     }
