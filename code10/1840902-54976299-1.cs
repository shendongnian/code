csharp
class BaseEntityService : IEntityService<BaseEntity>
{
    public void DoSomething(BaseEntity entity) => throw new NotImplementedException();
}
class ChildBEntityService: IEntityService<ChildBEntity>
{
    public void DoSomething(BaseEntity entity) => throw new NotImplementedException();
}
Write this:
csharp
class BaseEntityService<T> : IEntityService<T> where T : BaseEntity
{
    public void DoSomething(T entity) => throw new NotImplementedException();
}
class ChildBEntityService<T> : IEntityService<T> where T : ChildBEntity
{
    public void DoSomething(T entity) => throw new NotImplementedException();
}
The services are now generic, with a type constraint describing the *least specific* entity type they're able to handle. As a bonus, `DoSomething` now adheres to the Liskov Substitution Principle.
Now, register all of the services as open generics.
csharp
container.Collection.Register(typeof(IEntityService<>), new[] {
    typeof(BaseEntityService<>),
    typeof(GrandChildAEntityService<>),
    typeof(ChildBEntityService<>),
});
Simple Injector understands the generic type constraints. When resolving, the container will, essentially, filter the collection down to only those services for which the type constraint is satisfied.
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
    container.Collection.Register(typeof(IEntityService<>), new[] {
        typeof(BaseEntityService<>),
        typeof(GrandChildAEntityService<>),
        typeof(ChildBEntityService<>),
    });
    container.Verify();
    var serviceType = typeof(IEntityService<>).MakeGenericType(entityType);
    Assert.Equal(
        container.GetAllInstances(serviceType).Select(s => s.GetType()).OrderBy(t => t.Name),
        expectedServiceTypes.OrderBy(t => t.Name)
    );
}
Similar to your example, you can add `ChildAEntityService<T> : IEntityService<T> where T : ChildAEntity`, and everything works out...
csharp
[Theory]
[InlineData(typeof(GrandChildAEntity), new[] { typeof(GrandChildAEntityService<GrandChildAEntity>), typeof(ChildAEntityService<GrandChildAEntity>), typeof(BaseEntityService<GrandChildAEntity>) })]
[InlineData(typeof(BaseEntity), new[] { typeof(BaseEntityService<BaseEntity>) })]
[InlineData(typeof(ChildBEntity), new[] { typeof(ChildBEntityService<ChildBEntity>), typeof(BaseEntityService<ChildBEntity>) })]
[InlineData(typeof(ChildAEntity), new[] { typeof(ChildAEntityService<ChildAEntity>), typeof(BaseEntityService<ChildAEntity>) })]
public void Test2(Type entityType, Type[] expectedServiceTypes)
{
    var container = new Container();
    container.Collection.Register(typeof(IEntityService<>), new[] {
        typeof(BaseEntityService<>),
        typeof(GrandChildAEntityService<>),
        typeof(ChildBEntityService<>),
        typeof(ChildAEntityService<>),
    });
    container.Verify();
    var serviceType = typeof(IEntityService<>).MakeGenericType(entityType);
    Assert.Equal(
        container.GetAllInstances(serviceType).Select(s => s.GetType()).OrderBy(t => t.Name),
        expectedServiceTypes.OrderBy(t => t.Name)
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
