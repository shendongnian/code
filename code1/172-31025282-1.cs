        [Test]
	    public void ToAgeTests()
        {
            var date = new DateTime(2000, 1, 1);
            Assert.AreEqual("0 year(s), 0 month(s), 1 days(s)", new DateTime(1999, 12, 31).ToAge(date));
            Assert.AreEqual("0 year(s), 0 month(s), 0 days(s)", new DateTime(2000, 1, 1).ToAge(date));
            Assert.AreEqual("1 year(s), 0 month(s), 0 days(s)", new DateTime(1999, 1, 1).ToAge(date));
            Assert.AreEqual("0 year(s), 11 month(s), 0 days(s)", new DateTime(1999, 2, 1).ToAge(date));
            Assert.AreEqual("0 year(s), 10 month(s), 25 days(s)", new DateTime(1999, 2, 4).ToAge(date));
            Assert.AreEqual("0 year(s), 10 month(s), 1 days(s)", new DateTime(1999, 2, 28).ToAge(date));
            date = new DateTime(2000, 2, 15);
            Assert.AreEqual("0 year(s), 0 month(s), 28 days(s)", new DateTime(2000, 1, 18).ToAge(date));
        }
