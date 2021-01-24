     int userinput = 0;
     // Keep on asking until valid input - an integer number in [1..10] range
     while (true) {
       Console.WriteLine("Enter a number between 1 and 10");
 
       if (!int.TryParse(Console.ReadLine(), out userinput))
         Console.WriteLine("Sorry, syntax error; try again");
       else if (userinput < 0)
         Console.WriteLine("Your input less than 0; try again");  
       else if (userinput > 10)
         Console.WriteLine("Your input greate than 10; try again");  
       else
         break; // <- Valid input
     } 
