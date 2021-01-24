    var list = new[] { new { Id = 1, Name = "name" } }.ToList();
    foreach (var item in list)
    {
        int id = item.Id;
        string name = item.Name;
    }
