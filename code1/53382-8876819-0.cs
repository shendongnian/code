    public class PositioningReader : TextReader {
        private TextReader _inner;
        public PositioningReader(TextReader inner) {
            _inner = inner;
        }
        public override void Close() {
            _inner.Close();
        }
        public override int Peek() {
            return _inner.Peek();
        }
        public override int Read() {
            var c = _inner.Read();
            if (c >= 0)
                AdvancePosition((Char)c);
            return c;
        }
        private int _linePos = 0;
        public int LinePos { get { return _linePos; } }
        private int _charPos = 0;
        public int CharPos { get { return _charPos; } }
        private int _matched = 0;
        private void AdvancePosition(Char c) {
            if (Environment.NewLine[_matched] == c) {
                _matched++;
                if (_matched == Environment.NewLine.Length) {
                    _linePos++;
                    _charPos = 0;
                    _matched = 0;
                }
            }
            else {
                _matched = 0;
                _charPos++;
            }
        }
    }
