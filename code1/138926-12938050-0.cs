    public interface IFoo {}
    public class SomeFoo : IFoo {}
    public class FooRegistry : Registry
    {
      public FooRegistry()
      {
        For<IFoo>().Use<SomeFoo>();
      }
    }
    [TestFixture]
    public class FooRegistryTests
    {
      [Test]
      public void ForIFoo_UseSomeFoo_AsDefaultInstance()
      {
        // Arrange
        var registry = new FooRegistry();
        // Act
        var pluginGraph = registry.Build();
        var iFooPluginFamily = pluginGraph.FindFamily(typeof(IFoo));
        var defaultInstance = iFooPluginFamily.GetDefaultInstance();
        // Assert
        Assert.IsTrue(defaultInstance.UsesConcreteType<SomeFoo>());
      }
    }
    public static class TestExtensions
    {
      public static bool UsesConcreteType<T>(this Instance instance)
      {
        var concreteTypeProperty = typeof (Instance).GetProperty("ConcreteType", BindingFlags.Instance | BindingFlags.NonPublic);
        if (concreteTypeProperty == null || concreteTypeProperty.PropertyType != typeof(Type))
        {
          Assert.Inconclusive("Unable to locate the internal StructureMap.Instance.ConcreteType property");
        }
        var propertyValue = concreteTypeProperty.GetValue(instance, new object[] {}) as Type;
        
        return typeof (T) == propertyValue;
      }
    }
