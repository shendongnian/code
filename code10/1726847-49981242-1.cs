    private void ReloadTree()
    {
        var categories = foos
            .GroupBy(x => x.Property1)
            .Select(x => new FooViewModel { Category = x.Key, Children = x.Select(y => new FooViewModel() { Category = y.Property2 }).ToArray() })
            .ToArray();
        bindingsTree.ItemsSource = categories;
    }
