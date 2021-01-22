    class CountingReader : StreamReader {
        private int _lineNumber = 0;
        public int LineNumber { get { return _lineNumber; } }
        public CountingReader(Stream stream) : base(stream) { }
        public override string ReadLine() {
            _lineNumber++;
            return base.ReadLine();
        }
    }
