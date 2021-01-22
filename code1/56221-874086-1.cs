    public IEnumerable<Item> Items
    {
        get
        {
            foreach (Item x in items)
            {
                yield return x;
            }
        }
    }
