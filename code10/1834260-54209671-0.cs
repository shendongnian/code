    public interface ICommandHandler<T> where T : FooCommand { }
    public class FooCommand { }
    public class BarCommand : FooCommand { }
    class FooCommandHandler : ICommandHandler<FooCommand> { }
    class BarCommandHandler : ICommandHandler<BarCommand> { }
    class BarCommandHandler2 : ICommandHandler<BarCommand> { }
    [TestClass]
    public class AutofacTests
    {
        [TestMethod]
        public void ContainerResolvesExpectedDependency()
        {
            var container = GetContainer();
            var barCommandHandlers = container.Resolve<IEnumerable<ICommandHandler<BarCommand>>>()
                .ToArray();
            Assert.AreEqual(2, barCommandHandlers.Length);
            Assert.IsTrue(barCommandHandlers.Any(bch => bch is BarCommandHandler));
            Assert.IsTrue(barCommandHandlers.Any(bch => bch is BarCommandHandler2));
            Assert.IsFalse(barCommandHandlers.Any(bch => bch is FooCommandHandler));
        }
        private IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FooCommandHandler>().As<ICommandHandler<FooCommand>>();
            builder.RegisterType<BarCommandHandler>().As<ICommandHandler<BarCommand>>();
            builder.RegisterType<BarCommandHandler2>().As<ICommandHandler<BarCommand>>();
            return builder.Build();
        }
    }
