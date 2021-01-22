    void Test()
    {
      string ret = "";
      SomeFunction(a=>ret=a);
    }
    
    void SomeFunction(string_ptr str)
    {
       str("setting string value");
    }
    
    delegate void string_ptr(string a);
