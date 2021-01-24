    public class MyClass: IDbDataParameter
    {
        public MyClass(string parameterName, object value)
        {
            ParameterName = parameterName;
            Value = value;
        }
        public MyClass(string parameterName, object value, DbType dbType)
        {
            ParameterName = parameterName;
            Value = value;
            DbType = dbType;
        }
        public DbType DbType { get; set; }
        public ParameterDirection Direction { get; set; }
        public bool IsNullable => throw new NotImplementedException();
        public string ParameterName { get; set; }
        public string SourceColumn { get; set; }
        public DataRowVersion SourceVersion { get; set; }
        public object Value { get; set; }
        public byte Precision { get; set; }
        public byte Scale { get; set; }
        public int Size { get; set; }
    }
