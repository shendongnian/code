    public class Someclass {
    
      void SomeInstanceMethod() 
        { System.Console.WriteLine(this.ToString()); }
    
      void static SomeStaticMethod(Someclass _this) 
        { System.Console.WriteLine(_this.ToString()); }
    
      public void static Main()
        {
           Someclass instance = new Someclass();
           instance.SomeInstanceMethod();
           SomeStaticMethod(instance);
        }
    }
