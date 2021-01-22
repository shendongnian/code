    public class NoCloseStreamWriter : StreamWriter
    {
        public NoCloseStreamWriter(Stream stream, Encoding encoding)
            : base(stream, encoding)
        {
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(false);
        }
    }
