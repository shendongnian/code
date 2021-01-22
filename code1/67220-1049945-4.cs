    using System;
    using System.Runtime.CompilerServices;
    struct MyStruct
    {
       public MyStruct(int p)
       {
          X = p;
       }
       public int X;
       // prevents optimization of the whole thing to a constant.
       [MethodImpl(MethodImplOptions.NoInlining)]
       static int GetSomeNumber()
       {
           return new Random().Next();
       }
       
       static void Main(string[] args)
       {
          MyStruct x = new MyStruct(GetSomeNumber());
          // the following line is to prevent further optimization:
          for (int i = inlinetest(x); i != 100 ; i /= 2) ; 
       }
       static int inlinetest(MyStruct x)
       {
          return x.X + 1;
       }
    }
