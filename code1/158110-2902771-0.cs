    interface IC : IA, IB { }
    
    void bar(object obj)
    {
      if (obj is IA && obj is IB)
      {
        IC x = (dynamic)obj;
        foo(x);
      }
    }
