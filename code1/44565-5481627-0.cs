    class Other{
     class Generic<T>
    {
      void met1(T x);
    }
    static void Main()
    {
      Generic<int> g = new Generic<int>();
      Generic<string> s = new Generic<string>();
    }
    }
