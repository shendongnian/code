    public class MyDecorationAttribute : Attribute{}
    
    [MyDecoration]
    public class MyDecoratedClass{}
    
    [TestFixture]
    public class DecorationTests
    {
        [Test]
        public void FindDecoratedClass()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var typesWithAttribute = GetTypesWithAttribute(currentAssembly);
            Assert.That(typesWithAttribute, 
                                  Is.EquivalentTo(new[] {typeof(MyDecoratedClass)}));
        }
    
        public IEnumerable<Type> GetTypesWithAttribute(Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(type => type.IsDefined(typeof(MyDecorationAttribute), false));
        }
    }
