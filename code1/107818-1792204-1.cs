    public class StreamReader : TextReader
    {
        public override void Close()
        {
            this.Dispose(true);
        }
        protected override void Dispose(bool disposing)
        {
            try
            {
                if ((this.Closable && disposing) && (this.stream != null))
                {
                    this.stream.Close();
                }
            }
            finally
            {
                if (this.Closable && (this.stream != null))
                {
                    this.stream = null;
                    this.encoding = null;
                    this.decoder = null;
                    this.byteBuffer = null;
                    this.charBuffer = null;
                    this.charPos = 0;
                    this.charLen = 0;
                    base.Dispose(disposing);
                }
            }
        }
    }
