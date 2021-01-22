    class DDict { // optional: generic
        private readonly Dictionary<int, Dictionary<string, string>> _Inner = new ...;
        public Dictionary<string, string> this (int index) {
            Dictionary<string, string> d;
            if (!_Inner.TryGetValue(index, out d)) {
                 d = new Dictionary<string, string>();
                 _Inner.Add(index, d);
            }
            return d;
        }
    }
    var dd = new DDict();
    dd[5]["a"] = "hi";
