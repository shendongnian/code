    public class MockedFileStream : MemoryStream {
        protected override void Dispose(bool disposing) {
            //base.Dispose(disposing);
            //No Op fr the purposes of the test.
        }
        public override void Close() {
            //base.Close();
            //No Op fr the purposes of the test.
        }
        public void CustomDispose() {
            base.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
