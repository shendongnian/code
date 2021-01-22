    class testClass
    {
       private string _myString;
    
       public string myString { get { return _myString; } set { _myString = value; } }
    
       public testClass()
       {
          myString = "Hello";  // Initial value.
       }
    }
