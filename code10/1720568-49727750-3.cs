    var columnId = new MySortableColumn<int>()
    {
        SortKeySelector = displayedItem => myDisplayedItem.Id,
    };
    var columnFullName = new MyStortableColumn<string>()
    {
        SortKeySelector = displayedItem => myDisplayedItem.Id,
    }
    // etc.
