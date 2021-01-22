        [Test]
        public void CanFormatFileSizes()
        {
            Assert.AreEqual("128 B", (128).ToBytes());
            Assert.AreEqual("1.00 KB", (1024).ToBytes());
            Assert.AreEqual("10.00 KB", (10240).ToBytes());
            Assert.AreEqual("100.00 KB", (102400).ToBytes());
            Assert.AreEqual("1.00 MB", (1048576).ToBytes());
        }
