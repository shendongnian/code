    void Main()
    {
       Console.WriteLine( Base.GetInt() ); // 1
       Console.WriteLine( Derived.GetInt() );  // 2
    }
    
    public class Base
    {
     public static int GetInt() 
     { 
       return 1; 
     }
    }
    
    public class Derived : Base
    {
      public static int GetInt()
      {
        return 2;
      }
    }
