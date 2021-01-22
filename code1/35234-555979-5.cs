    public class StringPool
    {
        private readonly Dictionary<string,string> contents =
            new Dictionary<string,string>();
        public string Add(string item)
        {
            string ret;
            if (!contents.TryGetValue(item, out ret))
            {
                contents[item] = item;
                ret = item;
            }
            return ret;
        }
    }
