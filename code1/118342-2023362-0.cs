    Type t = typeof(SomeOtherTypeInSameAssembly)
        .Assembly.GetType("ClassLibrary1.ABC");
    MethodInfo method = t.GetMethod("Create",
        BindingFlags.Public | BindingFlags.Static, null,
        new Type[] { typeof(String) },
        new ParameterModifier[0]);
    Object o = method.Invoke(null, new Object[] { "test" });
