    [TestFixture]
    class Program
    {
        static IEnumerable<int> GetInts()
        {
            yield return 1;
        }
        [Test]
        static void Maasd()
        {
            var i = GetInts();
            Assert.IsTrue(i is IEnumerable<int>);
        }
    }
