    [TestFixture(typeof(ArrayList))]
    [TestFixture(typeof(List<int>))]
    public class IList_Tests<TList> where TList : IList, new()
    {
        private IList list;
        [SetUp]
        public void CreateList()
        {
            this.list = new TList();
        }
        [Test]
        public void CanAddToList()
        {
            list.Add(1); list.Add(2); list.Add(3);
            Assert.AreEqual(3, list.Count);
        }
    }
