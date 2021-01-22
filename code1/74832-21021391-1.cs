    [TestClass]
    public class LINQExtensionsTest
    {
        [TestMethod]
        public void DistinctByTestDate()
        {
            var list = Enumerable.Range(0, 200).Select(i => new
            {
                Index = i,
                Date = DateTime.Today.AddDays(i%4)
            }).ToList();
            var distinctList = list.DistinctBy(l => l.Date).ToList();
            Assert.AreEqual(4, distinctList.Count);
            
            Assert.AreEqual(0, distinctList[0].Index);
            Assert.AreEqual(1, distinctList[1].Index);
            Assert.AreEqual(2, distinctList[2].Index);
            Assert.AreEqual(3, distinctList[3].Index);
            Assert.AreEqual(DateTime.Today, distinctList[0].Date);
            Assert.AreEqual(DateTime.Today.AddDays(1), distinctList[1].Date);
            Assert.AreEqual(DateTime.Today.AddDays(2), distinctList[2].Date);
            Assert.AreEqual(DateTime.Today.AddDays(3), distinctList[3].Date);
            Assert.AreEqual(200, list.Count);
        }
        [TestMethod]
        public void DistinctByTestInt()
        {
            var list = Enumerable.Range(0, 200).Select(i => new
            {
                Index = i % 4,
                Date = DateTime.Today.AddDays(i)
            }).ToList();
            var distinctList = list.DistinctBy(l => l.Index).ToList();
            Assert.AreEqual(4, distinctList.Count);
            Assert.AreEqual(0, distinctList[0].Index);
            Assert.AreEqual(1, distinctList[1].Index);
            Assert.AreEqual(2, distinctList[2].Index);
            Assert.AreEqual(3, distinctList[3].Index);
            Assert.AreEqual(DateTime.Today, distinctList[0].Date);
            Assert.AreEqual(DateTime.Today.AddDays(1), distinctList[1].Date);
            Assert.AreEqual(DateTime.Today.AddDays(2), distinctList[2].Date);
            Assert.AreEqual(DateTime.Today.AddDays(3), distinctList[3].Date);
            Assert.AreEqual(200, list.Count);
        }
        struct EqualityTester
        {
            public readonly int Index;
            public readonly DateTime Date;
            public EqualityTester(int index, DateTime date) : this()
            {
                Index = index;
                Date = date;
            }
        }
        [TestMethod]
        public void TestStruct()
        {
            var list = Enumerable.Range(0, 200)
                .Select(i => new EqualityTester(i, DateTime.Today.AddDays(i%4)))
                .ToList();
            var distinctDateList = list.DistinctBy(e => e.Date).ToList();
            var distinctIntList = list.DistinctBy(e => e.Index).ToList();
            Assert.AreEqual(4, distinctDateList.Count);
            Assert.AreEqual(200, distinctIntList.Count);
        }
    }
