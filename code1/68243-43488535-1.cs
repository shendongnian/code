    public delegate int MyMethodDelegate(int x, ref int y);
        [TestMethod]
        public void TestSomething()
        {
            //Arrange
            var mock = new Mock<ISomeInterface>();
            var y = 0;
            mock.Setup(m => m.MyMethod(It.IsAny<int>(), ref y))
            .DelegateReturns((MyMethodDelegate)((int x, ref int y)=>
             {
                y = 1;
                return 2;
             }));
        }
