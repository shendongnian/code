    var list = new[] { new { Id = 1, Name = "name" } }.ToList();
    list.Add(new { Id = 2, Name = "name2" });
    foreach (var item in list)
    {
        int id = item.Id;
        string name = item.Name;
    }
