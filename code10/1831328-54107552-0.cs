    public void ChangeBackGroundColor(string ColorName)
     {
         ConsoleColor consoleColor;
    
         if (Enum.TryParse(ColorName, out consoleColor))
         {
             // We now have an enum type.
             Console.BackgroundColor = consoleColor;
             Console.Clear();
         }
            
         //do whatever you want if it's invalid ColorName    
         Console.WriteLine("invalid color");
     }
