    public class ListWithDuplicates : List<KeyValuePair<string, string>>
    {
        public void Add(string key, string value)
        {
            var element = new KeyValuePair<string, string>(key, value);
            this.Add(element);
        }
    }
    var list = new ListWithDuplicates();
    list.Add("k1", "v1");
    list.Add("k1", "v2");
    list.Add("k1", "v3");
    foreach(var item in list)
    {
        string x = string.format("{0}={1}, ", item.Key, item.Value);
    }
