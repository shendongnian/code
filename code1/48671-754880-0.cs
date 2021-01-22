    class Base { }
    class Derived : Base { }
    
    object obj = new Derived();
    Type typ = typeof(Base);
    
    type.IsInstanceOfType(obj); // = true
    type.IsAssignableFrom(obj.GetType()); // = true
