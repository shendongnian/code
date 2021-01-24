    public static void Foo(ConcurrentDictionary<ulong, ItemWrapper> items, ulong itemId)
    {
        if (!items.TryGetValue(itemId, out ItemWrapper wrapper))
        {
            //no item
        }
        lock (wrapper)
        {
            if (wrapper.Item == null)
            {
                //no actual item
            }
            else
            {
                if (ShouldRemoveItem(wrapper.Item))
                {
                    wrapper.Item = null;
                }
            }
        }
    }
