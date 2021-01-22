    class C
    {
    #if DEBUG 
      public Stack<int> Path = new Stack<int>();
    #endif 
      [Conditional("DEBUG")] Push(int x) { Path.Push(x); }
      [Conditional("DEBUG")] Pop() { Path.Pop(); }
      public int Recursive(int n)
      { 
        Push(n);
        int result = 1;
        if (n > 1)
        {
          result = n * Recursive(n-1);
          DoSomethingDangerous(n);
        }
        Pop();
        return result;
      }
    }
