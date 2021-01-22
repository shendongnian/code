    public interface IColumn<T>
    {
        T Value { get; set; }
        T OriginalValue { get; set; }
    }
    
    public struct Column<T> : IColumn<T>
    {
        public T Value { get; set; }
        public T OriginalValue { get; set; }
    }
    
    public static class ColumnService
    {
        public static bool HasChanges<T, S>(T column) where T : IColumn<S>
        {
            return !(column.Value.Equals(column.OriginalValue));
        }
    
        public static void AcceptChanges<T, S>(T column) where T : IColumn<S>
        {
            column.Value = column.OriginalValue;
        }
    }
