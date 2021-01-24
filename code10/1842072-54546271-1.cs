csharp
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace _54542354.MediatorExample
{
    /**
     * Example Input/Output types
     **/
    abstract class ActionBase { }
    class ExampleAction : ActionBase { public string Name { get; set; } }
    class ReturnType { public string Id { get; set; } }
    /**
     * Interfaces
     **/
    interface IActionHandler<TAction> where TAction : ActionBase
    {
        IEnumerable<ReturnType> Handle(TAction action);
    }
    interface IActionHandlerMediator
    {
        IEnumerable<ReturnType> Handle(ActionBase action);
    }
    /**
     * Example implementations
     **/
    class ExampleHandler : IActionHandler<ExampleAction>
    {
        public IEnumerable<ReturnType> Handle(ExampleAction action)
        {
            yield return new ReturnType{ Id = $"{action.Name}_First" };
            yield return new ReturnType{ Id = $"{action.Name}_Second" };
        }
    }
    class ActionHandlerMediator : IActionHandlerMediator
    {
        readonly ILifetimeScope container;
        public ActionHandlerMediator(ILifetimeScope container)
            => this.container = container;
        public IEnumerable<ReturnType> Handle(ActionBase action)
        {
            // TODO: Error handling. What if no strategy is registered for the provided type?
            dynamic handler = container.Resolve(typeof(IActionHandler<>)
                .MakeGenericType(action.GetType()));
            return (IEnumerable<ReturnType>)handler.Handle((dynamic)action);
        }
    }
    /**
     * Usage example
     **/
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestMediator()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ExampleHandler>().As<IActionHandler<ExampleAction>>();
            builder.RegisterType<ActionHandlerMediator>().As<IActionHandlerMediator>();
            var container = builder.Build();
            var handler = container.Resolve<IActionHandlerMediator>();
            var result = handler.Handle(new ExampleAction() { Name = "MyName" });
            Assert.AreEqual("MyName_First", result.First().Id);
            Assert.AreEqual("MyName_Second", result.Last().Id);
        }
    }
}
# Original Answer
I took a stab at running your sample code. I had to tweak some things out of the box, but I think it actually worked as you want it to (after my tweaks).
Here's what I ended up with:
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
