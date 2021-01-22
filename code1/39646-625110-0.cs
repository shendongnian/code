    public List<SomeModel> GetModels(Predicate<SomeModel> predicate)
    {
        return _models.Where(m => predicate(m))
                      .Select(m => new SomeModel(m))
                      .ToList();
    }
