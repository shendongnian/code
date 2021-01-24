    public class MyClass
    {
       private bool myValueSet = false;
       private string _myValue;
    
       public string MyValue
       {
          set {
            if (!muValueSet)
            {
              _myValue = value;
            }
          }
          get {
            return _myValue; 
          }
       }
    }
