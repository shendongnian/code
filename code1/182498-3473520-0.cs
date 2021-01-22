    public interface ITest { string TestMethod(); }
    public class Testing
    {
        [Test]
        public void TestMethod()
        {
            var testMock = new Mock<ITest>();
            testMock.Setup(x => x.TestMethod()).Returns("String val");
            var xyz = testMock.Object;
            Assert.AreEqual(1, 1);
        }
    }
