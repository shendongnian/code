        [TestMethod]
        public void ParserTest()
        {
            Mock<IParser> parserMock = new Mock<IParser>();
            int outVal;
            parserMock
                .Setup(p => p.TryParse("6", out outVal))
                .OutCallback((string t, out int v) => v = 6)
                .Returns(true);
            int actualValue;
            bool ret = parserMock.Object.TryParse("6", out actualValue);
            Assert.IsTrue(ret);
            Assert.AreEqual(6, actualValue);
        }
  
