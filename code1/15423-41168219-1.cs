    public class NumericStringComparerTests
    {
        [Fact]
        public void OrdersCorrectly()
        {
            AssertEqual("", "");
            AssertEqual(null, null);
            AssertEqual("Hello", "Hello");
            AssertEqual("Hello123", "Hello123");
            AssertEqual("123", "123");
            AssertEqual("123Hello", "123Hello");
            AssertOrdered("", "Hello");
            AssertOrdered(null, "Hello");
            AssertOrdered("Hello", "Hello1");
            AssertOrdered("Hello123", "Hello124");
            AssertOrdered("Hello123", "Hello133");
            AssertOrdered("Hello123", "Hello223");
            AssertOrdered("123", "124");
            AssertOrdered("123", "133");
            AssertOrdered("123", "223");
            AssertOrdered("123", "1234");
            AssertOrdered("123", "2345");
            AssertOrdered("0", "1");
            AssertOrdered("123Hello", "124Hello");
            AssertOrdered("123Hello", "133Hello");
            AssertOrdered("123Hello", "223Hello");
            AssertOrdered("123Hello", "1234Hello");
        }
        private static void AssertEqual(string x, string y)
        {
            Assert.Equal(0, NumericStringComparer.Instance.Compare(x, y));
            Assert.Equal(0, NumericStringComparer.Instance.Compare(y, x));
        }
        private static void AssertOrdered(string x, string y)
        {
            Assert.Equal(-1, NumericStringComparer.Instance.Compare(x, y));
            Assert.Equal( 1, NumericStringComparer.Instance.Compare(y, x));
        }
    }
