    public class MyClass
    {
        // Could use another generic type if preferred
        private readonly Dictionary<string, dynamic> _dictionary = new Dictionary<string, dynamic>();
        public void MyFunction(params dynamic[] kvps)
        {
            foreach (dynamic kvp in kvps)
                _dictionary.Add(kvp.Key, kvp.Value);
        }
    }
