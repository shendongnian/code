    int i = 0;
    List<string> names = new List<string>{ "Name1", "Name2", "Name3", "Name10" };
    //names.Sort();
    string available = names
        .Select(n => new { name = n, index = int.Parse(n.Substring(4)) })
        .TakeWhile(a => { i++; return a.index == i; })
        .OrderBy(a => a.index)
        .Select(a => "Name" + (a.index + 1))
        .Last();
