        [TestMethod]
        public void IsInUnitTest()
        {
            Assert.IsTrue(UnitTestDetector.IsInUnitTest, 
                "Should detect that we are running inside a unit test."); // lol
        }
