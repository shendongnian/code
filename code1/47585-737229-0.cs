    string txt = "Hello, world!";
    while ( doingSomething )
    {
      Console.Write(txt);
      System.Threading.Thread.Sleep(20);
      Console.CursorLeft -= txt.Length;
      for ( int i = 0; i < txt.Length; i++ )
        Console.Write(" ");
    }
