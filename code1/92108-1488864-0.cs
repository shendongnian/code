    class A
    {
      private string _Name
      public string Name
      {
        get { return _Name; }
        set 
        {
          if (value == null)
             throw new ArgumentNullException("Name");
          _Name = value;
        }
      }
    
      public A(string name)
      {
         //Note the use of property with built in validation
         Name = name;
      }
    }
