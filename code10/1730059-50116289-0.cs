    var itemsSource = DataGridInsRep.ItemsSource as IEnumerable;
    if (itemsSource != null)
    {
        foreach (var item in itemsSource.OfType<YourClass>())
        {
            Dtest.MCode = item.MCode;
            //...
        }
    }
