        ForRequestedType<ICommand>()
            .CacheBy(StructureMap.Attributes.InstanceScope.Singleton)
            .TheDefault.Is.OfConcreteType<A>()
            .EnrichWith(x => new DecoratorTwo(new DecoratorOne(x)));
        InstanceOf<ICommand>().Is
            .OfConcreteType<B>()
            .EnrichWith(x => new DecoratorOne(x))
            .WithName("second");
        InstanceOf<ICommand>().Is
            .OfConcreteType<MultiCommand>()
            .TheArrayOf<ICommand>().Contains(y =>
            {
                y.TheDefault();
                y.TheInstanceNamed("second");
            })
            .WithName("multi");
