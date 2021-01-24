    var container = new Container();
    
    container.Collection.Append<IMode, Mode1>();
    container.Collection.Append<IMode, Mode2>();
    container.RegisterConditional(
        typeof(IGrouping),
        c => typeof(Grouping<>).MakeGenericType(c.Consumer.ImplementationType),
        Lifestyle.Transient,
        c => true);
    container.RegisterConditional<IGroupingStrategy, Strategy1>(
        c => c.Consumer.ImplementationType.GetGenericArguments().Single() == typeof(Mode1));
    container.RegisterConditional<IGroupingStrategy, Strategy2>(
        c => c.Consumer.ImplementationType.GetGenericArguments().Single() == typeof(Mode2));
