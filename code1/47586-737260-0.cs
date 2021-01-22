    string txt = "Hello, world!";
    while (true)
    {
          // Show text
          Console.Write(txt);
          Console.CursorLeft -= txt.Length;
          System.Threading.Thread.Sleep(500); 
          // Show blank
          for (int i = 0; i < txt.Length; i++) Console.Write(" ");
          Console.CursorLeft -= txt.Length;
          System.Threading.Thread.Sleep(500); 
    }
