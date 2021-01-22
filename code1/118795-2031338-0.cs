    // cs_keyword_stackalloc.cs
    // compile with: /unsafe
    using System; 
    
    class Test
    {
       public static unsafe void Main() 
       {
          int* fib = stackalloc int[100];
          int* p = fib;
          *p++ = *p++ = 1;
          for (int i=2; i<100; ++i, ++p)
             *p = p[-1] + p[-2];
          for (int i=0; i<10; ++i)
             Console.WriteLine (fib[i]);
       }
    }
