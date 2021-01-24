csharp
[TestMethod]
public void TestStrategyPattern_Dict()
{
    // Define the available strategies
    var dict = new Dictionary<Type, Func<Parent, IEnumerable<object>>>();
    dict.Add(typeof(ChildA), x => new ChildAStrategy().CreateObjects(x));
    dict.Add(typeof(ChildB), x => new ChildBStrategy().CreateObjects(x));
    // Create the input object
    Parent child = new ChildA();
    // Invoke the strategy
    IEnumerable<object> enumerable = dict[child.GetType()](child);
    // Verify the results
    Assert.AreEqual("child A", enumerable.Single());
}
[TestMethod]
public void TestStrategyPattern_AutoFac()
{
    // Define the available strategies
    var builder = new ContainerBuilder();
    builder.RegisterType<ChildAStrategy>().As<IChildStrategy<ChildA>>();
    builder.RegisterType<ChildBStrategy>().As<IChildStrategy<ChildB>>();
    var container = builder.Build();
    // Create the input object
    Parent child = new ChildA();
    // Resolve the strategy
    // Because we don't know exactly what type the container will return,
    // we need to use `dynamic`
    dynamic strategy = container.Resolve(typeof(IChildStrategy<>)
        .MakeGenericType(child.GetType()));
    // Invoke the strategy
    IEnumerable<object> enumerable = strategy.CreateObjects(child);
    // Verify the results
    Assert.AreEqual("child A", enumerable.Single());
}
These tests both pass. I did not change any code outside of the tests.
The two main changes I introduced are:
* Use of `.Single()` before asserting. This is necessary because the strategy returns an `IEnumerable`, but the assertion is expecting the first object from that enumerable.
* Use of the `dynamic` type when resolving the strategy from AutoFac. This is necessary because the compiler can't tell what type AutoFac will return. In the original code, the returned type was `object`, which doesn't have a `CreateObjects(Parent)` method. `dynamic` lets us call any method we want--the compiler will just assume it exists. We'll get a runtime exception if the method doesn't exist, but because we know we just created an `IChildStrategy<>`, we can be confident that the method will exist.
