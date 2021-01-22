    [TestClass]
    public class AttributeListTest
    {
        private class TestAttrAttribute : Attribute
        {
        }
        [TestAttr]
        private class TestClass
        {
        }
        [TestMethod]
        public void Test()
        {
            var attributeList = AttributeList.GetCustomAttributeList(typeof (TestClass));
            Assert.IsTrue(attributeList.IsAttributeSet<TestAttrAttribute>());
            Assert.IsFalse(attributeList.IsAttributeSet<TestClassAttribute>());
            Assert.IsInstanceOfType(attributeList.FindAttribute<TestAttrAttribute>(), typeof(TestAttrAttribute));
        }
    }
