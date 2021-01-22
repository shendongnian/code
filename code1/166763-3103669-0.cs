        [TestMethod]
        public void ShortCircuitNullCoalesceTest()
        {
            const string foo = "foo";
            var result = foo ?? Bar();
            Assert.AreEqual(result, foo);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShortCircuitNullCoalesceFails()
        {
            const string foo = null;
            var result = foo ?? Bar();
        }
        private static string Bar()
        {
            throw new ArgumentException("Bar was called");
        }
