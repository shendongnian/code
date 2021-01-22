    // hasty code, might be written poorly
    public abstract class FileParser<T> {
        private readonly List<T> _contents;
        public IEnumerable<T> Contents {
            get { return _contents.AsReadOnly(); }
        }
    
        protected FileParser() {
            _contents = new List<T>();
        }
    
        public void ReadFile(string path) {
            if (!File.Exists(path))
                return;
    
            using (var reader = new StreamReader(path)) {
                while (!reader.EndOfStream) {
                    T value;
                    if (TryParseLine(reader.ReadLine(), out value))
                        _contents.Add(value);
                }
            }
        }
    
        protected abstract bool TryParseLine(string text, out T value);
    }
