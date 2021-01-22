        [Test]
        public void ConvertToDateWillHaveTwoDatesEqual()
        {
            DateTime d1 = new DateTime(2008, 1, 1);
            DateTime d2 = new DateTime(2008, 1, 2);
            Assert.IsTrue(d1 < d2);
            DateTime d3 = new DateTime(2008, 1, 1,7,0,0);
            DateTime d4 = new DateTime(2008, 1, 1,10,0,0);
            Assert.IsTrue(d3 < d4);
            Assert.IsFalse(d3.Date < d4.Date);
        }
