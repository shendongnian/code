    // any of these can be determined at runtime
    Type t = typeof(Bar);
    string methodToCall = "FunctionThatExistsInBarType";
    Type[] argumentTypes = new Type[0];
    object[] arguments = new object[0];
    object foo;
    // invoke the method - 
    // example ignores overloading and exception handling for brevity
    // assumption: return type is void or you don't care about it
    t.GetMethod(methodToCall, BindingFalgs.Public | BindingFlags.Instance)
        .Invoke(foo, arguments);
