    void SortColumn(SortableColumn column)
    {
         var sortedItems = Sort(column.SortKeySelector, ListSortOrder...);
         Display(sortedItems);
    }
