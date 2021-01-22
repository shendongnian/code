    public class MyRow : IStringIndexable, System.Collections.IEnumerable,
        ICollection<KeyValuePair<string, string>>,
        IEnumerable<KeyValuePair<string, string>>,
        IDictionary<string, string>
    {
        ICollection<string> Keys { }
    }
