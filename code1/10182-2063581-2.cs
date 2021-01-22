   public class Pair&lt;X, Y&gt;
    {
        X _x;
        Y _y;
        public Pair(X first, Y second)
        {
            _x = first;
            _y = second;
        }
        public X first { get { return _x; } }
        public Y second { get { return _y; } }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj == this)
                return true;
            Pair&lt;X, Y&gt; other = obj as Pair&lt;X, Y&gt;;
            if (other == null)
                return false;
            return
                (((first == null) && (other.first == null))
                    || ((first != null) && first.Equals(other.first)))
                  &&
                (((second == null) && (other.second == null))
                    || ((second != null) && second.Equals(other.second)));
        }
        public override int GetHashCode()
        {
            int hashcode = 0;
            if (first != null)
                hashcode += first.GetHashCode();
            if (second != null)
                hashcode += second.GetHashCode();
            return hashcode;
        }
    }
Here is some test code
   [TestClass()]
    public class PairTest
    {
        [TestMethod()]
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
