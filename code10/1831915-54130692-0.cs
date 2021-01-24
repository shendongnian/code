Configure.With(new CastleWindsorContainerAdapter(container))
    .Transport(t => t.UseMsmq("test"))
    .Options(o => o.EnableUnitOfWork(
        async context => new CustomUnitOfWork(context, connectionString),
        commitAction: async (context, uow) => await uow.Commit()
    ))
    .Start();
where `CustomUnitOfWork` would look something like this:
class CustomUnitOfWork
{
    public const string ItemsKey = "current-db-context";
 
    readonly MyDbContext _dbContext;
 
    public CustomUnitOfWork(IMessageContext messageContext, string connectionString)
    {
        _dbContext = new MyDbContext(connectionString);
        messageContext.TransactionContext.Items[ItemsKey] = this;
    }
 
    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
 
    public MyDbContext GetDbContext() => _dbContext;
}
and then you would set up your IoC container to resolve `MyDbContext` by fetching it from the current message context – with Castle Windsor, that would be done like this:
container.Register(
    Component.For<CustomUnitOfWork>()
        .UsingFactoryMethod(k =>
        {
            var messageContext = MessageContext.Current
                ?? throw new InvalidOperationException("Can't inject uow outside of Rebus handler");
 
            return messageContext.TransactionContext.Items
                .GetOrThrow<CustomUnitOfWork>(CustomUnitOfWork.ItemsKey);
        })
        .LifestyleTransient(),
 
    Component.For<MyDbContext>()
        .UsingFactoryMethod(k => k.Resolve<CustomUnitOfWork>().GetDbContext())
        .LifestyleTransient()
);
