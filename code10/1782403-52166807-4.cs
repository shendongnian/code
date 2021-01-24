    var users = data.Split(new[] {"\n\n" }, StringSplitOptions.None).Select(lines =>
    {
	    var line = lines.Split(new[] { "\n" }, StringSplitOptions.None);
		return new User(line[0].Substring(11), line[1].Substring(4), line[2].Substring(6), line[3].Substring(5));
    });
