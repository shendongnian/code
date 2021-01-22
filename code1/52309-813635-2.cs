	int group = 0;
	var lines =
	   strArray
	   .Select(s => new { Group = s == "xx" ? group++ : group, Value = s })
	   .GroupBy(n => n.Group)
	   .Skip(1)
	   .Where(g => g.Last().Value == "xx" && g.Count() > 1);
	foreach (var line in lines) {
	   Console.WriteLine(string.Join(",", line.Take(line.Count() - 1).Select(s => s.Value).ToArray()));
	}
