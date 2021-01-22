    [TestClass]
    public class PropertyNameHelperTest
    {
        private class TestClass
        {
            public static string StaticString { get; set; }
            public string InstanceString { get; set; }
        }
        [TestMethod]
        public void TestGetPropertyName()
        {
            Assert.AreEqual("StaticString", PropertyNameHelper.GetPropertyName(() => TestClass.StaticString));
            Assert.AreEqual("InstanceString", PropertyNameHelper.GetPropertyName((TestClass t) => t.InstanceString));
        }
    }
