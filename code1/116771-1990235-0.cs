    public sealed class StringCache {
        private readonly Dictionary<string,string> values
            = new Dictionary<string,string>(StringComparer.Ordinal);
        public string this[string value] {
            get {
                string cached;
                if (!values.TryGetValue(value, out cached)) {
                    values.Add(value, value);
                    cached = value;
                }
                return cached;
            }
        }
    }
