    var cmp = StringComparer.CurrentCultureIgnoreCase;
    var a = File.ReadAllLines(@"a.txt")
                .Select(line => line.Split(' '))
                .ToArray();
    var c = File.ReadAllLines(@"b.txt")
                .Select(line => line.Split('|'))
                .GroupBy(item => item[0], item => item[1])
                .Where(group => a.Any(item => item.Contains(group.Key, cmp)))
                .Select(group => group.Key + "|" + string.Join("|", group.ToArray()))
                .ToArray();
    File.WriteAllLines("result.txt", c);
