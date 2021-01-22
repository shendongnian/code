    [TestFixture]
    public class YourFixture
    {
        private TransactionScope scope;
        [SetUp]
        public void SetUp()
        {
            scope = new TransactionScope();
        }
        [TearDown]
        public void TearDown()
        {
            scope.Dispose();
        }
        [Test]
        public void YourTest() 
        {
            // your test code here
        }
    }
