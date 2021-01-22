    if (AttachConsole(ATTACH_PARENT_PROCESS))
      {
        System.IO.StreamWriter sw =
          new System.IO.StreamWriter(System.Console.OpenStandardOutput());
        sw.AutoFlush = true;
        System.Console.SetOut(sw);
        System.Console.SetError(sw);
      }
