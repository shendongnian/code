    struct MyStruct
    {
       public MyStruct(int p)
       {
          X = p;
       }
       public int X;
       static void Main(string[] args)
       {
          MyStruct x = new MyStruct(10);
          // the following line is to prevent further optimization:
          for (int i = inlinetest(x); i != 100 ; i /= 2) ; 
       }
    }
