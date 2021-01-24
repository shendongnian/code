    // Arrange.
    
    Container container = new Container();
    container.Configure( config =>
    {
        // register coffees / components
        config.For<ICoffee>().Use<LatteCoffee>().Named("Latte");
        config.For<ICoffee>().Use<CappuccinoCoffee>().Named("Cappuccino");
    
        // register addOns / decorators
        config.For<IAddOnDecorator>().Use<CaramelDecorator>().Named("Caramel");
        config.For<IAddOnDecorator>().Use<AlmondSyrupDecorator>().Named("Almond");
        config.For<IAddOnDecorator>().Use<SaltedCaramelDecorator>().Named("SaltedCaramel");
    });
    
    const string coffeeName = "Latte";
    IEnumerable<string> coffeeDecoratorNames = new List<string> { "SaltedCaramel", "Almond", "Caramel" };
    
    // Act.
    
    ICoffee theCoffee = container.GetInstance<ICoffee>(coffeeName);
    ExplicitArguments baseCoffee = new ExplicitArguments();
    baseCoffee.Set<ICoffee>(theCoffee);
    if (coffeeDecoratorNames.Any())
    {
        theCoffee = container.GetInstance<IAddOnDecorator>(baseCoffee, coffeeDecoratorNames.First());
    
        foreach (string nextDeco in coffeeDecoratorNames.Where(d => d != coffeeDecoratorNames.First()))
        {
            ExplicitArguments addOn = new ExplicitArguments();
            addOn.Set<ICoffee>(theCoffee);
            theCoffee = container.GetInstance<IAddOnDecorator>(addOn, nextDeco);
        }
    }
    
    
    // Assert.
    
    Assert.That(3.20m, Is.EqualTo(theCoffee.Cost));
