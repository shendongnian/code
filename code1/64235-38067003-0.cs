    // Interface for injection
    public interface IDatabase
    {
        // Original, non-functional signature:
        IDatatable<object> GetDataTable(Type dataType);
        // Functional method using a generic method:
        IDatatable<T> GetDataTable<T>();
    }
