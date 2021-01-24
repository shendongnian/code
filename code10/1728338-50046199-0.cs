    public class MockedFileStream : MemoryStream {
        protected override void Dispose(bool disposing) {
            //base.Dispose(disposing);
            //No Op fr the purposes of the test.
        }
        public void TestDispose() {
            base.Dispose(true);
        }
    }
