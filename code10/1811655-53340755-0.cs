    [TestClass]
    public class ReflectionTest
    {
        [TestMethod]
        public void ReflectionDiscoversBaseClassMethod()
        {
            var inheritedType = typeof(InheritedClass);
            var inheritedTypeMethods = inheritedType.GetMethods(
                BindingFlags.Public | BindingFlags.FlattenHierarchy);
            Assert.IsTrue(
                inheritedTypeMethods.Any(method => method.Name == "ImplementedMethod"));
        }
    }
    public abstract class BaseClass
    {
        public void ImplementedMethod()
        { }
    }
    public class InheritedClass : BaseClass { }
