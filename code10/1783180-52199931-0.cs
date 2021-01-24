     Console.WriteLine("Enter a, b, c or d:\r\n");
       string input = Console.ReadLine();
       while (input != "")
       {
         if (input == "a" || input == "b" || input == "c" || input == "d")
          {
           Console.WriteLine("Success\r\n");
          }
         else
          {
           Console.WriteLine("Fail\r\n");
          }
         Console.WriteLine("Enter a, b, c or d:");
         input = Console.ReadLine();
        }
