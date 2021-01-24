    // assuming you have a generic class named Class<> 
    // taking one generic type parameter
    Type generic = typeof(MyClassSuffix<>);
    Type typeParameter = typeof(MyClass);
    Type genericInstance = generic.MakeGenericType(typeParameter);
