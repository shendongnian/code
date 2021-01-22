    private void GoClick(object sender, EventArgs e)
    {
        string[] keys = {"Key1", "Key2", "Key3"};
        string source = "Key1:Value1Key2: ValueAnd A: To Test Key3:   Something Here";
        GetIt(keys, source);
    }
    private void GetIt(IEnumerable<string> keywords, string source) {
        var found = new Dictionary<string, string>(10);
        var keys = string.Join("|", keywords.ToArray());
        var matches = Regex.Matches(source, @"(?<key>" + keys + "):");            
        
        foreach (Match m in matches) {
            var key = m.Groups["key"].ToString();
            var start = m.Index + m.Length;
            var nx = m.NextMatch();
            var end = (nx.Success ? nx.Index : source.Length);
            found.Add(key, source.Substring(start, end - start));
        }
        foreach (var n in found) {
            Console.WriteLine("Key={0}, Value={1}", n.Key, n.Value);
        }                            
    }
