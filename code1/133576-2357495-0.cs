    public class Thing
    {
       private readonly string _value;
    
       public Thing(string value)
       {
          _value = value;
       }
    
       public string Value { get { return _value; } }
    }
