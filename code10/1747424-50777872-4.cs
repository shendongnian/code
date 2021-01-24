    if (matches.Count > 0) {
        Match last = matches[matches.Count - 1];
        DateTime dt = DateTime.Parse(last.Groups[1].Value);
        if (DateTime.Now > dt.AddMinutes(10)) {
             Console.WriteLine("Last date entry is older than 10 minutes ago: {0}", dt);
        }
    }
