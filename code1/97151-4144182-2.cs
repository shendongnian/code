    public static void PerformAction(params YourType[] items)
    {
        // Forward call to IEnumerable overload
        PerformAction(items.AsEnumerable());
    }
    public static void PerformAction(IEnumerable<YourType> items)
    {
        foreach (YourType item in items)
        {
            // Do stuff
        }
    }
