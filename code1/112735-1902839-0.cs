    private int GetInt()
    {
         try
         {
             return int.parse(Console.Readline().Trim());
         } 
          catch (exception e) 
         {
             Console.WriteLine(string.format("{0} Please try again", e.message);
             return GetInt();
         }
    }
