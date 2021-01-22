    public class Foo // TODO: Come up with an appropriate name :)
    {
        private readonly Dictionary<string, List<string>> dictionary =
            new Dictionary<string, List<string>>();
        public List<string> this[string key]
        {
            get
            {
                List<string> list;
                if (!dictionary.TryGetValue(key, out list))
                {
                    list = new List<string>();
                    dictionary[key] = list;
                }
                return list;
            }
        }
    }
