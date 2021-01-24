    ExternalClass externalClass = new ExternalClass();
        
    MethodInfo mi = GetType().GetMethod(nameof(MyMethod), BindingFlags.NonPublic | BindingFlags.Instance);
    PropertyInfo pi = externalClass.GetType().GetProperty("Inform", BindingFlags.NonPublic | BindingFlags.Instance);
    
    Delegate del = Delegate.CreateDelegate(pi.PropertyType, this, mi);
    Type type = externalClass.GetType().GetNestedType("Inform", BindingFlags.Public | BindingFlags.NonPublic);
    Delegate original = pi.GetValue(externalClass) as Delegate;
    Delegate combined = Delegate.Combine(original, del);
    
    pi.SetValue(externalClass, combined);
            
    externalClass.Foo(message);
