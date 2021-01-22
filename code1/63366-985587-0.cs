    class A
    {
      //ctor chaining
      public A():this(0)
      {  Console.WriteLine("default ctor"); }
      public A(int i)
      {  Init(i); }
      
      // what you want
      public A(string s)
      {  
        Console.WriteLine("string ctor overload" );
         Console.WriteLine("pre-processing" );
         Init(Int32.Parse(s));
         Console.WriteLine("post-processing" );
      }
    
       private void Init(int i)
       {
         Console.WriteLine("int ctor {0}", i);
       }
    }
