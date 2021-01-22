    interface ICrushable
    {
      void Crush();
    }
    
    public class Vehicle
    {
    }
    
    public class Animal
    {
    }
    
    public class Car : Vehicle, ICrushable
    {
      public void Crush()
      {
         Console.WriteLine( "Crrrrrassssh" );
      }
    }
    
    public class Gorilla : Animal, ICrushable
    {
      public void Crush()
      {
    	 Console.WriteLine( "Sqqqquuuuish" );
      }
    }
