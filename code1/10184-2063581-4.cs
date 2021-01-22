    [TestClass]
    public class PairTest
    {
        [TestMethod]
        public void pairTest()
        {
            string s = "abc";
            Pair&lt;int, string&gt; foo = new Pair&lt;int, string&gt;(10, s);
            Pair&lt;int, string&gt; bar = new Pair&lt;int, string&gt;(10, s);
            Pair&lt;int, string&gt; qux = new Pair&lt;int, string&gt;(20, s);
            Pair&lt;int, int&gt; aaa = new Pair&lt;int, int&gt;(10, 20);
            Assert.IsTrue(10 == foo.first);
            Assert.AreEqual(s, foo.second);
            Assert.AreEqual(foo, bar);
            Assert.IsTrue(foo.GetHashCode() == bar.GetHashCode());
            Assert.IsFalse(foo.Equals(qux));
            Assert.IsFalse(foo.Equals(null));
            Assert.IsFalse(foo.Equals(aaa));
            Pair&lt;string, string&gt; s1 = new Pair&lt;string, string&gt;("a", "b");
            Pair&lt;string, string&gt; s2 = new Pair&lt;string, string&gt;(null, "b");
            Pair&lt;string, string&gt; s3 = new Pair&lt;string, string&gt;("a", null);
            Pair&lt;string, string&gt; s4 = new Pair&lt;string, string&gt;(null, null);
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
