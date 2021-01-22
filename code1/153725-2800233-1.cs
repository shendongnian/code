    var className = "MyClass";
    var methodName = "MyMethod";
    //Get a reference to the Assembly that has the desired class. Assume that all classes that we dynamically invoke are in the same assembly as MyClass.
    
    var assembly = typeof(MyClass).Assembly;
    //Find the type that we want to create
    var type = assembly.GetTypes().FirstOrDefault(t=>t.Name == className);
    if(type != null) {
      //Create an instance of this type.
      var instance = Activator.CreateInstance(type);
      //Find the method and call it.
      instance.GetType().GetMethod(methodName).Invoke(instance);
    }
   
