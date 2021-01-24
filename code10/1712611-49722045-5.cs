    private static void ClearedCollection_CollectionChanged(object sender, 
    System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Console.Out.WriteLine(e.Action);
    }
