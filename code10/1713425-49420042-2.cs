    [TestMethod]
        public void GetDirectoriesSizesTest() {
            var actual = GetDirectorySizesBytes(@"C:\Exchanges");
            var parallelActual = ParallelGetDirectorySizesBytes(@"C:\Exchanges");
            long expected = 25769767281;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, parallelActual);
        }
