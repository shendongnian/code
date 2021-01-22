    [TestClass]
    public class PairTest
    {
        [TestMethod]
        public void pairTest()
        {
            string s = "abc";
            Pair<int, string> foo = new Pair<int, string>(10, s);
            Pair<int, string> bar = new Pair<int, string>(10, s);
            Pair<int, string> qux = new Pair<int, string>(20, s);
            Pair<int, int> aaa = new Pair<int, int>(10, 20);
            Assert.IsTrue(10 == foo.first);
            Assert.AreEqual(s, foo.second);
            Assert.AreEqual(foo, bar);
            Assert.IsTrue(foo.GetHashCode() == bar.GetHashCode());
            Assert.IsFalse(foo.Equals(qux));
            Assert.IsFalse(foo.Equals(null));
            Assert.IsFalse(foo.Equals(aaa));
            Pair<string, string> s1 = new Pair<string, string>("a", "b");
            Pair<string, string> s2 = new Pair<string, string>(null, "b");
            Pair<string, string> s3 = new Pair<string, string>("a", null);
            Pair<string, string> s4 = new Pair<string, string>(null, null);
            Assert.IsFalse(s1.Equals(s2));
            Assert.IsFalse(s1.Equals(s3));
            Assert.IsFalse(s1.Equals(s4));
            Assert.IsFalse(s2.Equals(s1));
            Assert.IsFalse(s3.Equals(s1));
            Assert.IsFalse(s2.Equals(s3));
            Assert.IsFalse(s4.Equals(s1));
            Assert.IsFalse(s1.Equals(s4));
        }
    }
