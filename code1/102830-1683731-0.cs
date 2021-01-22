        public enum enumA {one = 1, two = 2}
        public enum enumB {one = 1, two = 2}
        [Test]
        public void PreTest()
        {                       
            Assert.AreEqual((int)enumA.one, (int)enumB.one);
            // I don't think this one will ever pass
            Assert.AreSame(enumA.one, enumB.one); 
        }
