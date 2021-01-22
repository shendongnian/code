    public abstract class FormattedData {
        protected Dictionary<string, byte[]> _rawData = new Dictionary<string, byte[]>();
        public FormattedData(IEnumerable<KeyValuePair<string, int>> rawDataConfigs) {
            rawDataConfigs.ToList()
                .ForEach(kvp => _rawData.Add(kvp.Key, new byte[kvp.Value]));
        }
        public IEnumerable<string> RawDataNames {
            get {
                foreach (var kvp in _rawData) {
                    yield return kvp.Key;
                }
            }
        }
        public byte[] this[string rawDataName] {
            get {
                return _rawData[rawDataName];
            }
            set {
                if (value.Length != _rawData[rawDataName].Length) {
                    throw new ArgumentOutOfRangeException("RawData",
                        "The Raw Data byte array for a " + this.GetType().Name +
                        " must be " + _rawData[rawDataName].Length.ToString() + "-bytes long." +
                        Environment.NewLine +
                        "Length of supplied array: [" + value.Length.ToString() + "]");
                }
                _rawData[rawDataName] = value;
            }
        }
    }
