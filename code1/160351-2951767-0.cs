    public class MyValue
    {
       public int Value { get; set; }
       public static implicit operator bool( MyValue mb )
       {
           return mb.Value != 0;
       }
    }
    MyValue x = new MyValue() { Value = 10; }
    if( x ) { ... } // perfectly legal, compiler applies implicit conversion
