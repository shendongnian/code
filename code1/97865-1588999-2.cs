    class C
    {
      private Stack<int> path
#if DEBUG
        = new Stack<int>();
#else
        = null;
#endif
      public Stack<int> Path { get { return path; } }
      [Conditional("DEBUG")] private void Push(int x) { Path.Push(x); }
      [Conditional("DEBUG")] private void Pop() { Path.Pop(); }
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
