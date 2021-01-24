    public IEnumerable<Inventory> GetInventoryByItems(string[] items)
    {
        return _ctx.Pairs
            .Include(x => x.Attribute)
            .Where(x => items.All(item => x.Attribute.Item == item));
    }
