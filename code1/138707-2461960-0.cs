    void ProcessStep<T>(T delegateParam, params object[] parameters) where T : class {
        if (!(delegateParam is Delegate)) throw new ArgumentException();
        var del = delegateParam as Delegate;
        // use del.Method here to check the original method
       if (Attribute.IsDefined(del.Method, typeof(LogAttribute)))
       {
           //do something here [1]
       }
       del.DynamicInvoke(parameters);
    }
    
    ProcessStep<Action<bool>>(action, true);
    ProcessStep<Action<string, string>>(action, "Foo", "Bar")
