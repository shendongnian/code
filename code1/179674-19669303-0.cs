    public class Program
    {
      static int id = 0 , idOld = 0, idSelected = -1;
      static string[] samples;
    
      public static void Main()
      {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WindowWidth = 90;
        Console.WindowHeight = 36;
        Console.WindowTop = 5;
        Console.Title = "My Samples Application";
        Console.InputEncoding = Encoding.GetEncoding("windows-1251");
    			
        samples = new string[50];
        for (int i = 0; i < samples.Length; i++)
          samples[i] = "Sample" + i;
        LoopSamples();
      }
    
      static void SelectRow(int y, bool select)
      {
        Console.CursorTop = y + 1;
        Console.ForegroundColor = select ? ConsoleColor.Red : ConsoleColor.Yellow;
        Console.WriteLine("\t{0}", samples[y]);
        Console.CursorTop = y;
      }
    
      static void LoopSamples()
      {
        int last = samples.Length - 1;
        ShowSamples();
        SelectRow(0, true);
        while (true)
        {
          while (idSelected == -1)
          {
            idOld = id;
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
              case ConsoleKey.UpArrow:
              case ConsoleKey.LeftArrow: if (--id < 0) id = last; break;
              case ConsoleKey.DownArrow:
              case ConsoleKey.RightArrow: if (++id > last) id = 0; break;
              case ConsoleKey.Enter: idSelected = id; return;
              case ConsoleKey.Escape: return;
            }
            SelectRow(idOld, false);
            SelectRow(id, true);
          }
        }
      }
        
      static void ShowSamples()
      {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Use arrow keys to select a sample. Then press 'Enter'. Esc - to Quit");
        for (int i = 0; i < samples.Length; i++)
          Console.WriteLine("\t{0}", samples[i]);
      }
    }
