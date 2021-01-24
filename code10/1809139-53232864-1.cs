    var data = File.ReadAllLines(@"c:\temp\sample.txt");
    var names = data.Select(d => d.Split('\t'))
	.Select(s => new { Name = s[0], SubName = s[1] })
	.GroupBy(o => o.Name)
	.Select(g => new Name()
	{
		Name1 = g.Key,
		AssociatedSub = g.Select(v => new SubName() { Name = v.SubName }).ToList()
	});
    //This part is just to show the output
    foreach (var name in names)
    {
	    Console.WriteLine($"Name: {name.Name1}, AssociatedSub: {string.Join(",", name.AssociatedSub.Select(s => s.Name).ToArray())}");
    }
