    container.Collection.Append<IMode, Mode1>();
    container.Collection.Append<IMode, Mode2>();
    container.RegisterConditional<IGrouping>(
        Lifestyle.Transient.CreateRegistration(
            () => new Grouping(new Strategy1()),
            container),
        c => c.Consumer.ImplementationType == typeof(Mode1));
    container.RegisterConditional<IGrouping>(
        Lifestyle.Transient.CreateRegistration(
            () => new Grouping(new Strategy2()), 
            container),
        c => c.Consumer.ImplementationType == typeof(Mode2));
