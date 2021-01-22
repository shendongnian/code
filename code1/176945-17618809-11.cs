    [TestClass]
    public class IndexPropertyTests
    {
        [TestMethod]
        public void IndexPropertyTest()
        {
            var MyExample = new ExampleCollection<string>();
            MyExample.Add("a");
            MyExample.Add("b");
            Assert.IsTrue(MyExample.ExampleProperty[0] == "a");
            Assert.IsTrue(MyExample.ExampleProperty[1] == "b");
            MyExample.ExampleProperty[0] = "c";
            Assert.IsTrue(MyExample.ExampleProperty[0] == "c");
        }
    }
