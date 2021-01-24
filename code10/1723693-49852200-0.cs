    [TestFixture]
    public class Class1
    {
        [SetUp]
        public void RunBeforeAnyTest()
        {
            Console.WriteLine("RunBeforeAnyTest");
        }
        [TearDown]
        public void RunAfterEveryTest()
        {
            Console.WriteLine("RunAfterEveryTest");
        }
        [Test]
        public void Test1()
        {
            Console.WriteLine("Test1()");
        }
        [TestCase("case1")]
        [TestCase("case2")]
        public void Test2(string param)
        {
            Console.WriteLine($"Test2({param})");
        }
    }
