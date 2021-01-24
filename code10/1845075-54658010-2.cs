    public IEnumerator<Task> GetEnumerator()
    {
        return this.GetTasks().GetEnumerator();
    }
    IEnumerator IEnumerator.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    private IEnumerable<Task> GetTasks()
    {
        return this.dataTable.AsEnumerable()
           .Select(row => new Task
           {
               TaskId = row.Field<int>("TaskId"),
               Quantity = row.Field<int>("Quantity"),
               ...
           });
    }
