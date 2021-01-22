    [TestFixture(typeof(MySnazzyType))]
    [TestFixture(typeof(MyOtherSnazzyType))]
    public class Tests<T>
    {
        [Test]
        public void PoolCount_IsZero()
        {
            Assert.AreEqual(0, ConnectionPool_Accessor<T>._pool.Count);
        }
    }
