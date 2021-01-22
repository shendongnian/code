        class testclass
        {
            public string s { get; set; }
            public string s2 { get; set; }
            public int i { get; set; }
        }
        [TestMethod]
        public void TestMethod2()
        {
            testclass x = new testclass();
            string nameOfPropertyS = this.GetPropertyName(() => x.s);
            Assert.AreEqual("s", nameOfPropertyS);
            string nameOfPropertyI = x.GetPropertyName(() => x.i);
            Assert.AreEqual("i", nameOfPropertyI);
        }
 
