    [TestMethod]
    public void RegisterIValidator_GetOrderValidatorInstanceSucceeds()
    {
        var container = new Container();
        container.Register(typeof(IValidator<>),  typeof(IValidator<>).Assembly);
        container.Verify();
        var orderValidator = container.GetInstance<IValidator<Order>>();
        Assert.IsInstanceOfType(orderValidator, typeof(OrderValidator));
    }
   
