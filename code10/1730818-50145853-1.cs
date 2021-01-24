    var repo = _repo.GetAsQueryable<Item>();
    if (setting == 1)
    {
        return repo.Select(i => new ItemDTO
        {
            Id = i.ItemId,
            DisplayName = i.NormalDescription
        });
    }
    if (setting == 2)
    {
        return repo.Select(i => new ItemDTO
        {
            Id = i.ItemId,
            DisplayName = i.LongDescription
        });
    }
    if (setting == 3)
    {
        return repo.Select(i => new ItemDTO
        {
            Id = i.ItemId,
            DisplayName = i.ShortDescription
        });
    }
    return repo.Select(i => new ItemDTO
    {
        Id = i.ItemId,
        DisplayName = String.Empty
    });
