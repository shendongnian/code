    [TestFixture]
    public class YieldExample
    {
        private int flag = 0;
        public IEnumerable<int> GetInts()
        {
            yield return 1;
            flag = 1;
            yield return 2;
            flag = 2;
            yield return 3;
            flag = 3;
        }
    
        [Test]
        public void Test()
        {
            int expectedFlag = 0;
            foreach (var i in GetInts())
            {
                Assert.That(flag, Is.EqualTo(expectedFlag));
                expectedFlag++;
            }
    
            Assert.That(flag, Is.EqualTo(expectedFlag));
        }
    }
