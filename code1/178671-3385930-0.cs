    private void SaveObjects<T>(dynamic currentItems)
    {
        dynamic typeDynamic = new StaticMembersDynamicWrapper(typeof(T));
        foreach (var item in currentItems)
        {
            if (item.ID != 0)
            {
                T className = typeDynamic.Load(item.ID);
            }
        }
    }
