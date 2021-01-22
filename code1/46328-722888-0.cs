    public enum SortDirection { Ascending, Decending }
    public void Sort<TKey>(ref List<Employee> list,
                           Func<Employee, TKey> sorter, SortDirection direction)
    {
      if (direction == SortDirection.Ascending)
        list = list.OrderBy(sorter);
      else
        list = list.OrderByDescending(sorter);
    }
