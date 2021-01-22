    private void flattenList(IEnumerable<T> list)
    {
        foreach (T item in list)
        {
            masterList.Add(item);
            
            if (item.Count > 0)
            {
                this.flattenList(item);
            }
        }
    }
