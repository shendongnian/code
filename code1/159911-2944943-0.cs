    [TestClass]
    public class MefTest
    {
        public const string ConstructorParameterContract = "FooConstructorParameterContract";
        [TestMethod]
        public void TestConstructorInjectionWithMultipleConstructors()
        {
            string ExpectedConstructorParameterValue = "42";
            var catalog = new TypeCatalog(typeof(Foo), typeof(FooImporter));
            var container = new CompositionContainer(catalog);
            container.ComposeExportedValue<string>(ConstructorParameterContract, ExpectedConstructorParameterValue);
            var fooImporter = container.GetExportedValue<FooImporter>();
            Assert.AreEqual(1, fooImporter.FooList.Count, "Expect a single IFoo import in the list");
            Assert.AreEqual(ExpectedConstructorParameterValue, fooImporter.FooList[0].Value.ConstructorParameter, "Expected foo's ConstructorParameter to have the correct value.");
        }
    }
    public interface IFoo
    {
        string ConstructorParameter { get; }
    }
    [Export(typeof(IFoo))]
    public class Foo : IFoo
    {
        public Foo()
        {
            ConstructorParameter = null;
        }
        [ImportingConstructor]
        public Foo([Import(MefTest.ConstructorParameterContract)]string constructorParameter)
        {
            this.ConstructorParameter = constructorParameter;
        }
        public string ConstructorParameter { get; private set; }
    }
    [Export]
    public class FooImporter
    {
        [ImportMany]
        public List<Lazy<IFoo>> FooList { get; set; }
    }
