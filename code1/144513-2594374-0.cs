    public class TrackingTextReader : TextReader
    {
        private TextReader _baseReader;
        private int _position;
        public TrackingTextReader(TextReader baseReader)
        {
            _baseReader = baseReader;
        }
        public override int Read()
        {
            _position++;
            return _baseReader.Read();
        }
        public override int Peek()
        {
            return _baseReader.Peek();
        }
        public int Position
        {
            get { return _position; }
        }
    }
