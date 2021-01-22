    class DDict { // optional: generic
        private readonly Dictionary<int, Dictionary<string, string>> _Inner = new ...;
        public Dictionary<string, string> this (int index) {
            Dictionary<string, string> d;
            if (!_Inner.TryGetValue(index)) {
                 _Inner.Add(index, new Dictionary<string, string>());
            }
        }
    }
