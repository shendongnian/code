    int i = 0;
    string prefix = "Name";
    List<string> names = new List<string>{ "Name1", "Name2", "Name3", "Name10" };
    //names.Sort();
    string available = names
        .Select(n => new { name = n, index = int.Parse(n.Substring(prefix.Length)) })
        .OrderBy(a => a.index)
        .TakeWhile(a => { i++; return a.index == i; })
        .Select(a => prefix + (a.index + 1))
        .Last();
