    public class MyBaseClass
    {
        public virtual void DoStuff() { }
        public virtual void DoOtherStuff() { }
    }
    public class MySubClass : MyBaseClass
    {
        public override void DoOtherStuff()
        {
            // different to to base
        }
    }
    public abstract class TestOfBaseClass
    {
        protected abstract MyBaseClass classUnderTest { get; }
        [TestMethod]
        public void TestDoStuff()
        {
            classUnderTest.DoStuff();
            Assert.StuffWasDone();
        }
    }
    [TestClass]
    public class WhenSubclassDoesStuff : TestOfBaseClass
    {
        protected override MyBaseClass classUnderTest
        {
            get { return new MySubClass(); }
        }
        [TestMethod]
        public void ShoudDoOtherStuff()
        {
            classUnderTest.DoOtherStuff();
            Assert.OtherStuffDone();
        }
    }
