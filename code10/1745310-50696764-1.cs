    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var f = new Form1();
            var createControl = f.GetType().GetMethod("CreateControl",
                BindingFlags.Instance | BindingFlags.NonPublic);
            createControl.Invoke(f, new object[] { true });
            var input = 0;
            var expected = 1;
            var actual = f.Method1(input);
            Assert.AreEqual(expected, actual);
        }
    }
