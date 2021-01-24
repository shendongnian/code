csharp
interface IEntityService<T>
{
    void DoSomething(T entity);
}
class BaseEntityService<T> : IEntityService<T> where T : BaseEntity
{
    public void DoSomething(T entity) => throw new NotImplementedException();
}
class ChildBEntityService<T> : IEntityService<T> where T : ChildBEntity
{
    public void DoSomething(T entity) => throw new NotImplementedException();
}
The services are now generic, with a type constraint describing the *least specific* entity type they're able to handle. As a bonus, `DoSomething` now adheres to the Liskov Substitution Principle. Since the service implementations provide type constraints, the `IEntityService` interface no longer needs one.
Register all of the services as a single collection of open generics. Simple Injector understands the generic type constraints. When resolving, the container will, essentially, filter the collection down to only those services for which the type constraint is satisfied.
Here's a working example, presented as an [xUnit](https://xunit.github.io) test.
csharp
[Theory]
[InlineData(typeof(GrandChildAEntity), new[] { typeof(GrandChildAEntityService<GrandChildAEntity>), typeof(BaseEntityService<GrandChildAEntity>) })]
[InlineData(typeof(BaseEntity), new[] { typeof(BaseEntityService<BaseEntity>) })]
[InlineData(typeof(ChildBEntity), new[] { typeof(ChildBEntityService<ChildBEntity>), typeof(BaseEntityService<ChildBEntity>) })]
[InlineData(typeof(ChildAEntity), new[] { typeof(BaseEntityService<ChildAEntity>) })]
public void Test1(Type entityType, Type[] expectedServiceTypes)
{
    var container = new Container();
    
    // Services will be resolved in the order they were registered
    container.Collection.Register(typeof(IEntityService<>), new[] {
        typeof(ChildBEntityService<>),
        typeof(GrandChildAEntityService<>),
        typeof(BaseEntityService<>),
    });
    container.Verify();
    var serviceType = typeof(IEntityService<>).MakeGenericType(entityType);
    Assert.Equal(
        expectedServiceTypes,
        container.GetAllInstances(serviceType).Select(s => s.GetType())
    );
}
Similar to your example, you can add `ChildAEntityService<T> : IEntityService<T> where T : ChildAEntity` and `UnusualEntityService<T> : IEntityService<T> where T : IUnusualEntity` and everything works out...
csharp
[Theory]
[InlineData(typeof(GrandChildAEntity), new[] { typeof(UnusualEntityService<GrandChildAEntity>), typeof(ChildAEntityService<GrandChildAEntity>), typeof(GrandChildAEntityService<GrandChildAEntity>), typeof(BaseEntityService<GrandChildAEntity>) })]
[InlineData(typeof(BaseEntity), new[] { typeof(BaseEntityService<BaseEntity>) })]
[InlineData(typeof(ChildBEntity), new[] { typeof(UnusualEntityService<ChildBEntity>), typeof(ChildBEntityService<ChildBEntity>), typeof(BaseEntityService<ChildBEntity>) })]
[InlineData(typeof(ChildAEntity), new[] { typeof(ChildAEntityService<ChildAEntity>), typeof(BaseEntityService<ChildAEntity>) })]
public void Test2(Type entityType, Type[] expectedServiceTypes)
{
    var container = new Container();
    // Services will be resolved in the order they were registered
    container.Collection.Register(typeof(IEntityService<>), new[] {
        typeof(UnusualEntityService<>),
        typeof(ChildAEntityService<>),
        typeof(ChildBEntityService<>),
        typeof(GrandChildAEntityService<>),
        typeof(BaseEntityService<>),
    });
    container.Verify();
    var serviceType = typeof(IEntityService<>).MakeGenericType(entityType);
    Assert.Equal(
        expectedServiceTypes,
        container.GetAllInstances(serviceType).Select(s => s.GetType())
    );
}
As I mentioned before, this example is specific to Simple Injector. Not all containers are able to handle generic registrations so elegantly. For example, a similar registration fails with [Microsoft's DI container](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/):
csharp
[Fact]
public void Test3()
{
    var services = new ServiceCollection()
        .AddTransient(typeof(IEntityService<>), typeof(BaseEntityService<>))
        .AddTransient(typeof(IEntityService<>), typeof(GrandChildAEntityService<>))
        .AddTransient(typeof(IEntityService<>), typeof(ChildBEntityService<>))
        .BuildServiceProvider();
    // Exception message: System.ArgumentException : GenericArguments[0], 'GrandChildBEntity', on 'GrandChildAEntityService`1[T]' violates the constraint of type 'T'.
    Assert.Throws<ArgumentException>(
        () => services.GetServices(typeof(IEntityService<ChildBEntity>))
    );
}
# With Other DI Frameworks
I've devised an alternate solution that should work with any DI container.
This time, we remove the generic type definition from the interface. Instead, the `CanHandle()` method will let the caller know whether an instance can handle a given entity.
csharp
interface IEntityService
{
    // Indicates whether or not the instance is able to handle the entity.
    bool CanHandle(BaseEntity entity);
    void DoSomething(BaseEntity entity);
}
A boilerplate implementation of the interface would look like:
csharp
abstract class GenericEntityService<T> : IEntityService
{
    // Indicates that the service can handle an entity of typeof(T),
    // or of a type that inherits from typeof(T).
    public bool CanHandle(BaseEntity entity)
        => typeof(T).IsAssignableFrom(entity.GetType());
    public void DoSomething(BaseEntity entity)
    {
        // This could also throw an ArgumentException, although that would
        // violate the Liskov Substitution Principle.
        if (!CanHandle(entity)) return;
        DoSomethingImpl(entity);
    }
    protected abstract void DoSomethingImpl(BaseEntity entity);
}
Which means the actual service implemtnations look like:
csharp
class BaseEntityService : GenericEntityService<BaseEntity>
{
    protected override void DoSomethingImpl(BaseEntity entity) => throw new NotImplementedException();
}
class ChildBEntityService : GenericEntityService<ChildBEntity>
{
    protected override void DoSomethingImpl(BaseEntity entity) => throw new NotImplementedException();
}
To get them out of the DI container, you'll want a friendly factory:
csharp
class EntityServiceFactory
{
    readonly IServiceProvider serviceProvider;
    public EntityServiceFactory(IServiceProvider serviceProvider)
        => this.serviceProvider = serviceProvider;
    public IEnumerable<IEntityService> GetServices(BaseEntity entity)
        => serviceProvider
            .GetServices<IEntityService>()
            .Where(s => s.CanHandle(entity));
}
And finally, to prove it all works:
csharp
[Theory]
[InlineData(typeof(GrandChildAEntity), new[] { typeof(UnusualEntityService), typeof(ChildAEntityService), typeof(GrandChildAEntityService), typeof(BaseEntityService) })]
[InlineData(typeof(BaseEntity), new[] { typeof(BaseEntityService) })]
[InlineData(typeof(ChildBEntity), new[] { typeof(UnusualEntityService), typeof(ChildBEntityService), typeof(BaseEntityService) })]
[InlineData(typeof(ChildAEntity), new[] { typeof(ChildAEntityService), typeof(BaseEntityService) })]
public void Test4(Type entityType, Type[] expectedServiceTypes)
{
    // Services appear to be resolved in reverse order of registration, but
    // I'm not sure if this behavior is guaranteed.
    var serviceProvider = new ServiceCollection()
        .AddTransient<IEntityService, UnusualEntityService>()
        .AddTransient<IEntityService, ChildAEntityService>()
        .AddTransient<IEntityService, ChildBEntityService>()
        .AddTransient<IEntityService, GrandChildAEntityService>()
        .AddTransient<IEntityService, BaseEntityService>()
        .AddTransient<EntityServiceFactory>() // this should have an interface, but I omitted it to keep the example concise
        .BuildServiceProvider();
    // Don't get hung up on this line--it's part of the test, not the solution.
    BaseEntity entity = (dynamic)Activator.CreateInstance(entityType);
    var entityServices = serviceProvider
        .GetService<EntityServiceFactory>()
        .GetServices(entity);
    Assert.Equal(
        expectedServiceTypes,
        entityServices.Select(s => s.GetType())
    );
}
I don't think this is as elegant as the Simple Injector implementation, but it's still pretty good. The pattern has some precedent. It's very similar to the implementation of MVC Core's [Policy-Based Authorization](https://docs.microsoft.com/en-us/aspnet/core/security/authorization/policies?view=aspnetcore-2.2#use-a-handler-for-one-requirement); specifically [`AuthorizationHandler`](https://github.com/aspnet/AspNetCore/blob/68f0aff1440e61e15eaa90d098c0f136fbbb4c64/src/Security/Authorization/Core/src/AuthorizationHandler.cs).
