    using System;
    
    public static class Test
    {
        static unsafe void Swap(this int a, int* pa, int* pb)
          {
              int temp = a;
              *pa = *pb;
              *pb = temp;
          }
    
    	public static unsafe void Main()
    	{
         var a = 5;
         var b = 6;
         a.Swap(&a, &b);
         Console.WriteLine("a={0},b={1}", a, b);
      	}
    }
