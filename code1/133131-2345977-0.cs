    private readonly ICollection<Item> Items = new SynchronizedCollection<Item>();
    // Run this on the background thread.
    public void PopulateItems()
    {
        using (var file = File.OpenRead("BigFile.txt"))
        using (var reader = new StreamReader(file))
        {
            while (!reader.EndOfStream)
            {
                var item = new Item();
                PopulateItem(item);
                Items.Add(item);
            }
        }
    }
    public void PopulateItem(Item item)
    {
        // Do time-consuming work.
    }
