    // Clears all properties in object
    ClearProperties(Obj);
    // Clears all properties in object from MyInterface1 & MyInterface2 
    ClearProperties(Obj, new List<Type>(){ typeof(MyInterface1), typeof(MyInterface2));
    // Clears all integer properties in object from MyInterface1 & MyInterface2
    ClearProperties(Obj, new List<Type>(){ typeof(MyInterface1), typeof(MyInterface2), typeof(int));
    // Clears all integer properties in object
    ClearProperties(Obj,typeof(int));
    // Lastly you can pass Reflection Flags to get even more control. Ex; Clear all properties declared by this instance
    ClearProperties(Obj, null, null, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.DeclaredOnly);
