    public class SomeInt : LikeType<int>
    {
        public SomeInt(int value) : base(value) { }
    }
    [TestClass]
    public class HashSetExample
    {
        [TestMethod]
        public void Contains_WhenInstanceAdded_ReturnsTrueWhenTestedWithDifferentInstanceHavingSameValue()
        {
            var myInt = new SomeInt(42);
            var myIntCopy = new SomeInt(42);
            var otherInt = new SomeInt(4111);
            Assert.IsTrue(myInt == myIntCopy);
            Assert.IsFalse(myInt.Equals(otherInt));
            var mySet = new HashSet<SomeInt>();
            mySet.Add(myInt);
            Assert.IsTrue(mySet.Contains(myIntCopy));
        }
    }
