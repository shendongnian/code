    public class MyClass
    {
       private SubClass _mySubClass;
    
       public MyClass(SubClass subClass)
       {
          _mySubClass = subClass;
       }
    
       public PropertyType Property
       {
          get { return _subClass.Property;}
       }   
    }
