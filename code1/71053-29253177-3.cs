    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanChainStrings()
        {
            ICollection<string> strings = new List<string>();
    
            strings.AddItem("Another").AddItem("String");
    
            Assert.AreEqual(2, strings.Count);
        }
    }
