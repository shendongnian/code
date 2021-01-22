    public void ForEachItem(Action action)
    {
        foreach (Item item in items)
        {
            action(item);
        }
    }
