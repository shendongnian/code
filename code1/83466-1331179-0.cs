    void Main()
    {
    	var e = new Example();
    	I   i = e as I;
    	
    	e.m1();  // prints Class m1()
    	i.m1();  // prints Interface m1()
    }
    
    public interface I
    {
      void m1();
    }
    
    public class Example : I
    {
      public void m1()
      {
        Console.WriteLine( "Class m1()" );
      }
      
      void I.m1()
      {
        Console.WriteLine( "Interface m1()" );
      }
    }
