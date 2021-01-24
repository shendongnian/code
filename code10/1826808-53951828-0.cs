     public static bool PromptForInt(string promptString, out int result, string helpString = null)
     {
         while (true)
         {
             Console.WriteLine(promptString);
             var response = Console.ReadLine();
             if (string.Equals(response, "Q", StringComparison.OrdinalIgnoreCase))
             {
                 result = 0;
                 return false;
             }
             if (helpString != null && string.Equals(response, "H", StringComparison.InvariantCultureIgnoreCase))
             {
                 Console.WriteLine(helpString);
                 continue;   //skip back to the top of the loop
             }
             if (int.TryParse(response, out result))
             {
                 return true;
             }
         }
     }
