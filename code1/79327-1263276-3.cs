    protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
    {
        IEnumerable<MyClass> query = base.Items;
        if (direction == ListSortDirection.Ascending)
            query = query.OrderBy( i => prop.GetValue(i) );
        else
            query = query.OrderByDescending( i => prop.GetValue(i) );
        int newIndex = 0;
        foreach (MyClass item in query)
        {
            this.Items[newIndex] = item;
            newIndex++;
        }
        this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
    }
