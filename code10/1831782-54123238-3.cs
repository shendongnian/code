    public void Write(params object[] oo)
    {
      foreach(var o in oo)
        if(o == null)
          Console.ResetColor();
        else if(o is ConsoleColor)
          Console.ForegroundColor = o as ConsoleColor;
        else
          Console.Write(o.ToString());
    }
