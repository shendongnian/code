    // Via 'dynamic'    
    dynamic dx = GetSomeCLRObject();
    dx.DoSomething();
    dx.SomeMember = 2;
    // Via Reflection
    object x = GetSomeCLRObject();
    Type xt = x.GetType();
    MemberInfo DoSomethingMethod = xt.GetMethod("DoSomething");
    DoSomethingMethod.Invoke(x, null);
    PropertyInfo SomeMemberProperty = xt.GetProperty("SomeMember");
    SomeMemberProperty.SetValue(x, 2);
