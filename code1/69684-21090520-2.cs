    [TestClass]
    public class ExtensionTests {
        [TestMethod]
        public void GetShallowCloneByReflection_PropsAndFields()
        {
            var uri = new Uri("http://www.stackoverflow.com");
            var source = new TestClassParent();
            source.SomePublicString = "Pu";
            source.SomePrivateString = "Pr";
            source.SomeInternalString = "I";
            source.SomeIntField = 6;
            source.SomeList = new List<Uri>() { uri };
            var dest = source.GetShallowCopyByReflection<TestClassChild>();
            Assert.AreEqual("Pu", dest.SomePublicString);
            Assert.AreEqual("Pr", dest.SomePrivateString);
            Assert.AreEqual("I", dest.SomeInternalString);
            Assert.AreEqual(6, dest.SomeIntField);
            Assert.AreSame(source.SomeList, dest.SomeList);
            Assert.AreSame(uri, dest.SomeList[0]);            
        }
    }
    
    internal class TestClassParent
    {
        public String SomePublicString { get; set; }
        internal String SomeInternalString { get; set; }
        internal String SomePrivateString { get; set; }
        public String SomeGetOnlyString { get { return "Get"; } }
        internal List<Uri> SomeList { get; set; }
        internal int SomeIntField;
    }
    internal class TestClassChild : TestClassParent
    {
    }
