    static void DoAction(params int[] args)
    {
      foreach (int arg in args)
      {
        Console.WriteLine(arg);
        if (arg == 93) goto exit;
      }
      //edit:
      if (args.Length > 3) goto exit;
      //Do another gazillion actions you might wanna skip.
      //etc.
      //etc.
    exit:
      Console.Write("Delete resource or whatever");
    }
