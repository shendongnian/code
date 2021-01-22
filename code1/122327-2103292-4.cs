    class LineReader : IEnumerable<string>, IDisposable {
            TextReader _reader;
            public LineReader(TextReader reader) {
                _reader = reader;
            }
            public IEnumerator<string> GetEnumerator() {
                string line;
                while ((line = _reader.ReadLine()) != null) {
                    yield return line;
                }
            }
            IEnumerator IEnumerable.GetEnumerator() {
                return GetEnumerator();
            }
            public void Dispose() {
                _reader.Dispose();
            }
        }
