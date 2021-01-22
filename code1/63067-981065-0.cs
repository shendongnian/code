    public class Example
    {
        public Dictionary<Int32, String> DictionaryProperty
        {
            get; set;
        }
        public Example()
        {
            DictionaryProperty = new Dictionary<int, string>();
        }
    }
    public class MainForm
    {
        public MainForm()
        {
            Example e = new Example();
            e.DictionaryProperty.Add(1, "Hello");
            e.DictionaryProperty.Remove(1);
        }
    }
