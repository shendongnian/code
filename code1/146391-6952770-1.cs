        [TestMethod, ExpectContractFailure]
        public void Test_Constructor2_NullArg()
        {
            IEnumerable arg = null;
            MyClass mc = new MyClass(arg);
        }
