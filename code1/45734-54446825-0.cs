    public class StringPoolXmlTextReader : XmlTextReader
    {
        private readonly Dictionary<string, string> stringPool = new Dictionary<string, string>();
        internal StringPoolXmlTextReader(Stream stream)
            : base(stream)
        {
        }
        public override string Value
        {
            get
            {
                if (this.NodeType == XmlNodeType.Attribute)
                    return GetOrAddFromPool(base.Value);
                return base.Value;
            }
        }
        private string GetOrAddFromPool(string str)
        {
            if (str == null)
                return null;
            if (stringPool.TryGetValue(str, out var res) == false)
            {
                res = str;
                stringPool.Add(str, str);
            }
            return res;
        }
    }
