        var props =  bindingContext.ModelType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance).ToList();
        bindingContext.ModelType.GetInterfaces()
                          .ToList()
                          .ForEach(i => props.AddRange(i.GetProperties()));
            
        foreach (var property in props)
