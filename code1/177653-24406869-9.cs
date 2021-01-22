        [TestMethod]
        public void TestSignal()
        {
            var fileSignal = new FileSignal(Path.GetTempFileName());
            var fileSignal2 = new FileSignal(fileSignal.FilePath);
            Assert.IsFalse(fileSignal.CheckIfSignalled());
            Assert.IsFalse(fileSignal2.CheckIfSignalled());
            Assert.AreEqual(fileSignal.LastSignal, fileSignal2.LastSignal);
            fileSignal.Signal();
            Assert.IsFalse(fileSignal.CheckIfSignalled());
            Assert.AreNotEqual(fileSignal.LastSignal, fileSignal2.LastSignal);
            Assert.IsTrue(fileSignal2.CheckIfSignalled());
            Assert.AreEqual(fileSignal.LastSignal, fileSignal2.LastSignal);
            Assert.IsFalse(fileSignal2.CheckIfSignalled());
        }
