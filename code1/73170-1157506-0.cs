    public class MyClass2
       {
        private List<int> whack = new List<int>();
        // lots of other field initializers
    
        public MyClass2()
        {
           Console.WriteLine("Default ctor");
        }
        public MyClass2(string s)
        {
           Console.WriteLine("String overload");
        }
          // lots of other overload ctors
       }
