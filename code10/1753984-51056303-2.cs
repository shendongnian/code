    public IEnumerable<ModelSearch> GetBySearchString(string searchString)
    {
        return _list.Where(
            m => m.Title.Contains(searchString, StringComparison.InvariantCultureIgnoreCase) ||
            m.Variants.Any(v => v.Title.Contains(searchString, StringComparison.InvariantCultureIgnoreCase))
        )
        .Select( m =>
            new ModelSearch
            {
                ID = m.ID,
                Title = m.Title,
                Variants = m.Variants.Where(v => v.Title.Contains(searchString, StringComparison.InvariantCultureIgnoreCase)).ToList()
            }
        )
        .AsEnumerable();
    }
