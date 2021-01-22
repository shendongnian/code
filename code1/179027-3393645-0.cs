    public class Class1
    {
       public Class1()
       {
       }
       public Class1(int a)
       {
       }
    }
    public class Class2 :Class1
    {
       public Class2(int a) : base(a)
       {
       }
       public Class2(): this(2)
       {
       }
    }
