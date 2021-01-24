    private static void EmptyList_CollectionChanged(object sender, 
    System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Console.Out.WriteLine(e.Action);
    }
