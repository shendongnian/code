    public Class MyClass
    {
       private SubClass _mySubClass;
    
       public Class(SubClass subClass)
       {
          _mySubClass = subClass;
       }
    
       public PropertyType Property
       {
          get { return _subClass.Property;}
       }   
    }
