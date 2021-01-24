    public class MyClass
    {
       private bool myValueSet = false;
       private string _myValue;
    
       public string MyValue
       {
          set {
            if (!myValueSet)
            {
              _myValue = value;
            }
          }
          get {
            return _myValue; 
          }
       }
    }
