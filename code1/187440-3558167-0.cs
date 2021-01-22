    using NUnit.Framework;
    namespace ClassLibrary1
    {
    [TestFixture]
    public class TestFixtureBase
    {
        [SetUp]
        public virtual void Setup()
        {
            // setup code here
        }
        [Test]
        public void CommonTest1()
        {
            Assert.True(true);
        }
        [Test]
        public void CommonTest2()
        {
            Assert.False(false);
        }
    }
    public class MyClassTests : TestFixtureBase
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            // additional setup code
        }
        [Test]
        public void MyClassTest1()
        {
            Assert.True(true);
        }
    }
    }
