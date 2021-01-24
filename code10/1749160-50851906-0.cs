    container.RegisterConditional<IEnumerable<IStudent>>(
        container.Collection.CreateRegistration<IStudent>(
            typeof(Student1)),
        c => c.Consumer.Target.GetCustomAttribute<namedAttribute>()?.Name == "Senior");
    container.RegisterConditional<IEnumerable<IStudent>>(
        container.Collection.CreateRegistration<IStudent>(
            typeof(Student2),
            typeof(Student3)),
        c => c.Consumer.Target.GetCustomAttribute<namedAttribute>()?.Name == "Junior");
