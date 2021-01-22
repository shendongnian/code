    public class MyDict
    {
        private readonly IDictionary<string, int> values = new Dictionary<string, int>();
        public int this[int i, bool b]
        {
            get
            {
                string key = BuildKey(i, b);
                return values[key];
            }
            set
            {
                string key = BuildKey(i, b);
                values[key] = value;
            }
        }
        private static string BuildKey(int i, bool b)
        {
            return string.Concat(i, '\0', b);
        }
    }
