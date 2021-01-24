    var container = new Container();
    
    container.Collection.Append<IMode, Mode1>();
    container.Collection.Append<IMode, Mode2>();
    container.RegisterConditional(
        typeof(ICommonBuilder),
        c => typeof(CommonBuilder<>).MakeGenericType(c.Consumer.ImplementationType),
        Lifestyle.Transient,
        c => true);
    container.RegisterConditional(
        typeof(IGrouping),
        c => typeof(Grouping<>).MakeGenericType(c.Consumer.ImplementationType),
        Lifestyle.Transient,
        c => true);
    container.RegisterConditional<IGroupingStrategy, Strategy1>(
        c => typeof(Model1) == c.Consumer.ImplementationType
            .GetGenericArguments().Single() // Consumer.Consumer
            .GetGenericArguments().Single(); // Consumer.Consumer.Consumer
    container.RegisterConditional<IGroupingStrategy, Strategy2>(
        c => typeof(Mode2)) == c.Consumer.ImplementationType
            .GetGenericArguments().Single()
            .GetGenericArguments().Single();
