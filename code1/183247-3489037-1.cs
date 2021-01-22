    public class RowKey<T>
    {
        public string DbName { get; set; }
        public T GetValue():
    }
    // Now use RowKey<int>, RowKey<string>, RowKey<Guid>, etc.
