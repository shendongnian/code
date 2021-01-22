    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class QuestionColumnAttribute : Attribute
    {
        public string ColumnName { get; private set; }
        public QuestionColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
