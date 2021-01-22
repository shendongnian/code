    sealed public class PeekDataReader : IDataReader
    {
        private IDataReader wrappedReader;
        private bool wasPeeked;
        private bool lastResult;
        public PeekDataReader(IDataReader wrappedReader)
        {
            this.wrappedReader = wrappedReader;
        }
        public bool Peek()
        {
            // If the previous operation was a peek, do not move...
            if (this.wasPeeked)
                return this.lastResult;
            // This is the first peek for the current position, so read and tag
            bool result = Read();
            this.wasPeeked = true;
            return result;
        }
        public bool Read()
        {
            // If last operation was a peek, do not actually read
            if (this.wasPeeked)
            {
                this.wasPeeked = false;
                return this.lastResult;
            }
            // Remember the result for any subsequent peeks
            this.lastResult = this.wrappedReader.Read();
            return this.lastResult;
        }
        public bool NextResult()
        {
            this.wasPeeked = false;
            return this.wrappedReader.NextResult();
        }
        // Add pass-through operations for all other IDataReader methods
        // that simply call on 'this.wrappedReader'
    }
