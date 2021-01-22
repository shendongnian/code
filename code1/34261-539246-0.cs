    public class Foo
    {
       private int val1;
       private List<int> list;
       public Foo()
       {
          //could also be a private constructor if that's appropriate
          //all default initialization
          val1 = 1;
          list = new List<int>();
       }
    
       public Foo(int nonDefaultValue1) : this()
       {
          //set inputted value
          val1 = nonDefaultValue1;
          //no need to initialize list, done by default constructor
       }
    }
