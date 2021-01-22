    [TestFixture]
    public class BTSTest
    {
        private class iC : IComparer<int>{public int Compare(int x, int y){return x.CompareTo(y);}}
        [Test]
        public void Test()
        {
            BinaryTreeSearch<int, int> bts = new BinaryTreeSearch<int, int>(new iC());
            bts.Add(5, 1);
            bts.Add(5, 2);
            bts.Add(6, 2);
            bts.Add(2, 3);
            bts.Add(8, 2);
            bts.Add(10, 11);
            bts.Add(9, 4);
            bts.Add(3, 32);
            bts.Add(12, 32);
            bts.Add(8, 32);
            bts.Add(9, 32);
            Assert.AreEqual(11, bts.Count);
            Assert.AreEqual(2, bts.Min);
            Assert.AreEqual(12, bts.Max);
            List<int> val = bts[5];
            Assert.AreEqual(2, val.Count);
            Assert.IsTrue(val.Contains(1));
            Assert.IsTrue(val.Contains(2));
            val = bts[6];
            Assert.AreEqual(1, val.Count);
            Assert.IsTrue(val.Contains(2));
            Assert.IsTrue(bts.Contains(5));
            Assert.IsFalse(bts.Contains(-1));
            val = bts.GetRange(5, 8);
            Assert.AreEqual(5, val.Count);
            Assert.IsTrue(val.Contains(1));
            Assert.IsTrue(val.Contains(32));
            Assert.AreEqual(3, val.Count<int>(num => num == 2));
            bts.Remove(8, 32);
            bts.Remove(5, 2);
            Assert.AreEqual(9, bts.Count);
            val = bts.GetRange(5, 8);
            Assert.AreEqual(3, val.Count);
            Assert.IsTrue(val.Contains(1));
            Assert.AreEqual(2, val.Count<int>(num => num == 2));
            bts.Remove(2, 3);
            Assert.IsNull(bts.FindNode(2));
            bts.Remove(12, 32);
            Assert.IsNull(bts.FindNode(12));
            Assert.AreEqual(3, bts.Min);
            Assert.AreEqual(10, bts.Max);
            bts.Remove(9, 4);
            bts.Remove(5, 1);
            bts.Remove(6, 2);
        }
    }
