    public class MyTemplate<T1,T2>
    {
         public MyTemplate(..args..) { ... } // constructor
    }
    public static class MyTemplate{
         public static MyTemplate<T1,T2> Create<T1,T2>(..args..)
         {
             return new MyTemplate<T1, T2>(... params ...);
         }
         public static MyTemplate<T1, string> Create<T1>(...args...)
         {
             return new MyTemplate<T1, string>(... params ...);
         }
    }
    
    var val1 = MyTemplate.Create<int,decimal>();
    var val2 = MyTemplate.Create<int>();
