    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanChainStrings()
        {
            ICollection&lt;string&gt; strings = new List&lt;string&gt;();
            strings.AddItem("Another").AddItem("String");
            Assert.AreEqual(2, strings.Count);
        }
    }
