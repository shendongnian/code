    public class ClaimWriterException : Exception
    {
        public ClaimWriterException()
        {
        }
        public ClaimWriterException(string message)
            : base(message)
        {
        }
        public ClaimWriterException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
