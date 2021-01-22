        [TestMethod()]
        public void getArrayTest()
        {
            Class1 target = new Class1(); 
            Array expected = new []{1,2,3,4,5}; 
            Array actual;
            actual = target.getArray();
            CollectionAssert.AreEqual(expected, actual);
            //Assert.IsTrue(expected.S actual, "is the test results");
        }
