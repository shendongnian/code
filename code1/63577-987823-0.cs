    public IList<T> BuildClause<T>(IList<T> value, object prefix)
    {
        Type type = typeof(T);
        if (type == typeof(string))
        {
            // handle string
        }
        else if (type == typeof(int))
        {
            // handle int
        }
        // ...
    }
    
    public class ColumnFilter<T>:
        where T: struct
    {
        public IList<T> Value { get; set; }
    }
    
    var colFilter = new ColumnFilter<string>
    {
        Value = new { "string 1", "string 2", "string 3" }
    }
    
    IList<string> values = BuildClause(colFilter.Value, prefix);
