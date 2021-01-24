    List<MyData> dataList = lines
        .Select(str => new { str, token = str.Split('.') })
        .Where(x => x.token.Length >= 4)
        .GroupBy(x => string.Concat(x.token.Take(4)))
        .Select(g => g.Select(x => x.str).ToList())
        .Where(list => list.Count == 3)
        .Select(MyDataFromList)
        .ToList();
    ...
    private static MyData MyDataFromList(List<string> parts) {
        if (parts.Count != 3) {
            throw new ArgumentException(nameof(parts));
        }
        var byType = parts
            .Select(ToTypeAndValue)
            .ToDictionary(t => t.Item1, t => t.Item2)
        return new MyData {
            DateTime = DateTime.Parse(byType["DateTime"])
        ,   Index = int.Parse(byType["Integer"])
        ,   Value = byType["String"]
        };
    }
    private static Tuple<string,string> ToTypeAndValue(string s) {
        var tokens = s.Split(',');
        if (tokens.Length != 3) return null;
        var typeParts = tokens[1].Split(':');
        if (typeParts.Length != 2 || typeParts[0] != "Type") return null;
        var valueParts = tokens[2].Split(':');
        if (valueParts.Length != 2 || valueParts[0] != "Value") return null;
        return Tuple.Create(typeParts[1].Trim(), typeParts[2].Trim());
    }
