        [TestMethod]
        public void IsIntoTheRange()
        {
            decimal dec = 54;
            Boolean result = false;
            result = dec.isInRange(50, 60); //result = True
            Assert.IsTrue(result);
            result = dec.isInRange(55, 60); //result = False
            Assert.IsFalse(result);
            result = dec.isInRange(54, 60); //result = True
            Assert.IsTrue(result);
            result = dec.isInRange(54, 60, false); //result = False
            Assert.IsFalse(result);
            result = dec.isInRange(32, 54, false, false);//result = False
            Assert.IsFalse(result);
            result = dec.isInRange(32, 54, false);//result = True
            Assert.IsTrue(result);
        }
