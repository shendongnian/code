    public void Write(string msg)
    {
      string[] ss = msg.Split('{','}');
      ConsoleColor c;
      foreach(var s in ss)
        if(s.StartsWith("/"))
          Console.ResetColor();
        else if(s.StartsWith("=") && Enum.TryParse(s.Substring(1), out c))
          Console.ForegroundColor = c;
        else
          Console.Write(s);
    }
