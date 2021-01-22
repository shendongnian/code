    public delegate void MyMethodDel(params object[] args);
    
    void MyPrintMethod(params object[] args)
    {
      switch (args.Length)
      {
        case 1:
          Console.WriteLine((string)args[0]);
          break;
        ...
        default:
          throw new InvalidArgumentCountException();
      }
    }
