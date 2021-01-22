    public class Foo
    {
       public String Bar { get; set; }
       private Int32 _intValue;
       public Int32 Value { get { return _intValue; } }
       override public ToString()
       {
          return "Bar: " + Bar + " has Value: " + Value;
       }
    }
