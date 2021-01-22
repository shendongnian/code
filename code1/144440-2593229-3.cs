    var a = new HashSet<string>(File.ReadAllLines(@"a.txt")
                                    .SelectMany(line => line.Split(' ')),
                                StringComparer.CurrentCultureIgnoreCase);
    var c = File.ReadAllLines(@"b.txt")
                .Select(line => line.Split('|'))
                .GroupBy(item => item[0], item => item[1])
                .Where(group => a.Contains(group.Key))
                .Select(group => group.Key + "|" + string.Join("|", group.ToArray()))
                .ToArray();
    File.WriteAllLines("result.txt", c);
