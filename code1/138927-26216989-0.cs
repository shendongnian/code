    [Test]
    public void Should_connect_delete_handler_by_registry() 
    {
         var container = new Container(new HandlerRegistry());
         var handler = container.GetInstance<IHandler<DeleteEntityCommand<Customer>>>();
         handler.ShouldBeInstanceOf<DeleteEntityCommandHandler<Customer>>(); 
    }
