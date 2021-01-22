        public interface IFoo { string GetBar(); }
        [TestMethod]
        public void TestRhino()
        {
            var fi = MockRepository.GenerateStub<IFoo>();
            fi.Stub(x => x.GetBar()).Return("A");
            Assert.AreEqual("A", fi.GetBar());
            // Switch to record to clear behaviour and then back to replay
            fi.BackToRecord(BackToRecordOptions.All);
            fi.Replay();
            fi.Stub(x => x.GetBar()).Return("B");
            Assert.AreEqual("B", fi.GetBar());
        }
