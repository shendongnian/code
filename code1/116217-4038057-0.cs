        [TestMethod]
        public void Test1()
        {
            IEnumerable<MyCustomClass> myCustomList = new MyCustomList()
                             {
                                 new MyCustomClass() { Int1 = 1},
                                 new MyCustomClass() { Int1 = 2},
                                 new MyCustomClass() { Int1 = 3},
                             };
            //Ignores MyCustomList method and uses IEnumerable<> method.
            Assert.AreEqual(2, myCustomList.Where(x => x.Int1 > 1).Count());
        }
        [TestMethod]
        public void Test2()
        {
            MyCustomList myCustomList = new MyCustomList()
                             {
                                 new MyCustomClass() { Int1 = 1},
                                 new MyCustomClass() { Int1 = 2},
                                 new MyCustomClass() { Int1 = 3},
                             };
            //Uses MyCustomList method
            Assert.AreEqual(1, myCustomList.Where(x => x.Int1 > 1).Count());
        }
        [TestMethod]
        public void Test3()
        {
            ISomeInterface myCustomList = new MyCustomList()
                             {
                                 new MyCustomClass() { Int1 = 1},
                                 new MyCustomClass() { Int1 = 2},
                                 new MyCustomClass() { Int1 = 3},
                             };
            //If your type is ISomeInterface, the compiler uses ISomeInterface method, even if the runtime instance is MyCustomList
            Assert.AreEqual(0, myCustomList.Where(x => x.Int1 > 1).Count());
        }
        
        [TestMethod]
        public void Test4()
        {
            MyDerivedCustomList myCustomList = new MyDerivedCustomList()
                             {
                                 new MyCustomClass() { Int1 = 1},
                                 new MyCustomClass() { Int1 = 2},
                                 new MyCustomClass() { Int1 = 3},
                             };
            //Even if MyDerivedCustomList implements ISomeInterface, the compiler uses MyCustomList method
            Assert.AreEqual(1, myCustomList.Where(x => x.Int1 > 1).Count());
        }
        [TestMethod]
        public void Test5()
        {
            ISomeInterface myCustomList = new MyDerivedCustomList()
                             {
                                 new MyCustomClass() { Int1 = 1},
                                 new MyCustomClass() { Int1 = 2},
                                 new MyCustomClass() { Int1 = 3},
                             };
            //If your type is ISomeInterface, the compiler uses ISomeInterface method, even if the runtime instance is MyDerivedCustomList
            Assert.AreEqual(0, myCustomList.Where(x => x.Int1 > 1).Count());
        }
