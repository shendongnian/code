    var users = data.Split(new[] {"\n\n" }, StringSplitOptions.None).Select(lines =>
    {
        var line = lines.Split(new[] { "\n" }, StringSplitOptions.None);
    	return new User(line[0].Remove(0, 12), line[1].Remove(0, 5), line[2].Remove(0, 7), line[3].Remove(0, 6));
    });
