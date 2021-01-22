     class Program
     {
        static void Main(string[] args)
        {
            MethodQueue(() => MethodOne(1, 2));
        }
      
        static void MethodOne(int x, int y)
        {...}
        static void MethodQueue(Action act)
        {
            act();
        }
      
     }
