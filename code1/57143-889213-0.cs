    public class Foo
    {
       private string _Bar = String.Empty;
       
       public string Bar
       {
          get { return _Bar; }
          set 
          {
              if (value == null)
                 throw new ArgumentNullException("Bar");
              _Bar = value;
          }
       }
      
       public Foo(string bar)
       {
          Bar = bar;
       }
    }
