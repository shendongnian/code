        [TestMethod]
        public void Test()
        {
            Assert.AreEqual("A", NumberToExcelColumn(1));
            Assert.AreEqual("Z", NumberToExcelColumn(26));
            Assert.AreEqual("AA", NumberToExcelColumn(27));
            Assert.AreEqual("AO", NumberToExcelColumn(41));
            Assert.AreEqual("AZ", NumberToExcelColumn(52));
            Assert.AreEqual("BA", NumberToExcelColumn(53));
            Assert.AreEqual("ZZ", NumberToExcelColumn(702));
            Assert.AreEqual("AAA", NumberToExcelColumn(703));
            Assert.AreEqual("ABC", NumberToExcelColumn(731));
            Assert.AreEqual("ACQ", NumberToExcelColumn(771));
            Assert.AreEqual("AYZ", NumberToExcelColumn(1352));
            Assert.AreEqual("AZA", NumberToExcelColumn(1353));
            Assert.AreEqual("AZB", NumberToExcelColumn(1354));
            Assert.AreEqual("BAA", NumberToExcelColumn(1379));
            Assert.AreEqual("CNU", NumberToExcelColumn(2413));
            Assert.AreEqual("GCM", NumberToExcelColumn(4823));
            Assert.AreEqual("MSR", NumberToExcelColumn(9300));
            Assert.AreEqual("OMB", NumberToExcelColumn(10480));
            Assert.AreEqual("ULV", NumberToExcelColumn(14530));
            Assert.AreEqual("XFD", NumberToExcelColumn(16384));
        }
