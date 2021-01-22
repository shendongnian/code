    class LineReader : IEnumerable<string> {
        Func<TextReader> _source;
        public LineReader(Func<Stream> streamSource) {
            _source = () => new StreamReader(streamSource());
        }
        public IEnumerator<string> GetEnumerator() {
            using (var reader = _source()) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    yield return line;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();   
        }
    }
