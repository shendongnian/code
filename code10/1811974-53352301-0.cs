        [TestMethod]
        public void TestMethod2()
        {
            var dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "dd-MM-yyyy"; // force to day-month-year
            string dt = "22-08-2018 16:53:00.000";
            var date = Convert.ToDateTime(dt, dtFormat);
            Assert.AreEqual(new DateTime(2018, 08, 22, 16, 53, 0), date);
        }
