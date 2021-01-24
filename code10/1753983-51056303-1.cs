    public IEnumerable<ModelSearch> GetBySearchString(string searchString)
    {
        return _list.Where(
            m => m.Title.Contains(searchString, StringComparison.InvariantCultureIgnoreCase) ||
            m.Variants.Any(v => v.Title.Contains(searchString, StringComparison.InvariantCultureIgnoreCase))
        ).AsEnumerable();
    }
