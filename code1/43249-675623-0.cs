    public static MyClass FactoryCreate(params Func<object, object>[] initializers)
    {
        var result = new MyClass();
        foreach (var init in initializers) 
        {
            var name = init.Method.GetParameters()[0].Name;
            var value = init(null);
            typeof(MyClass)
                .GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase)
                .SetValue(result, value, null);
        }
        return result;
    }
