    static void DoAction(params int[] args)
    {
      foreach (int arg in args)
      {
        Console.WriteLine(arg);
        if (arg == 93) goto exit;
      }
    exit:
      Console.Write("Delete resource or whatever");
    }
