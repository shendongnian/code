    using (var db = new DatabaseContext())
    {
        var words = Regex.Split(text, @"\s+");
        var query = db.Pages.AsQuerable();
        foreach(var word in words)
            query = query.Where(x => x.Text.ToLower().Contains(word.ToLower()));
        var answer = query.ToList();
    }
