        [TestMethod]
        public void TestOpenWithConfigurationAfterExplicit()
        {
            String dummy = typeof(MallApp).Assembly.FullName;  //force the assembly loaded.
            using (DbContext ctx = new DbContext("name=MyContainer))
            {
            }
        }
