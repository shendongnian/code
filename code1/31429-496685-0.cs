    public class StreamEnumerator : IEnumerable<char>
    {
        StreamReader _reader;
        public StreamEnumerator(Stream stm)
        {
            if (stm == null)
                throw new ArgumentNullException("stm");
            if (!stm.CanSeek)
                throw new ArgumentException("stream must be seekable", "stm");
            if (!stm.CanRead)
                throw new ArgumentException("stream must be readable", "stm");
            _reader = new StreamReader(stm);
        }
        public IEnumerator<char> GetEnumerator()
        {
            int c = 0;
            while ((c = _reader.Read()) >= 0)
            {
                yield return (char)c;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
