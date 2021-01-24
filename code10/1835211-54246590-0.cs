    static void Main(string[] args)
    {
        string path = @"t.txt";
        var text = File.ReadAllLines(path, Encoding.UTF8);
        var dict = new Dictionary<string, Dictionary<string, string>>();
        var id = "";
        var rows = text
            .Select(l => new { prop = l.Split(':')[0], val = l.Split(':')[1].Trim() })
            .ToList();
        foreach (var row in rows)
        {
            if (row.prop == "ID")
            {
                id = row.val;
            }
            else if (dict.ContainsKey(id))
            {
                dict[id].Add(row.prop, row.val);
            }
            else
            {
                dict[id] = new Dictionary<string, string>();
                dict[id].Add(row.prop, row.val);
            }
        }
       //get valid entries
       var validEntries = dict.Where(e =>e.Value.ContainsKey("Phone Number") && e.Value["Phone Number"] != "(n/a)").ToDictionary(x=>x.Key, x => x.Value);
    }
