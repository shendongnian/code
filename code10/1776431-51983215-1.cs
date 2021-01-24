    public class SqlServerDateTypeMapping : Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerDateTimeTypeMapping
    {
        public SqlServerDateTypeMapping() 
            : this(StringDateConverter.StringDateStorageType, System.Data.DbType.String)
        {
        }
        public SqlServerDateTypeMapping(string storeType, DbType? dbType = null) 
            : base(storeType, dbType)
        {
        }
        protected SqlServerDateTypeMapping(RelationalTypeMappingParameters parameters)
            : base(parameters)
        {
        }
        public override DbType? DbType => System.Data.DbType.String;
        protected override string SqlLiteralFormatString
            => StoreType == StringDateConverter.StringDateStorageType
                ? "'" + StringDateConverter.StringDateStorageFormat + "'"
                : base.SqlLiteralFormatString;
        public override ValueConverter Converter => new StringDateConverter();
        // ensure cloning returns an instance of this class
        public override RelationalTypeMapping Clone(in RelationalTypeMappingInfo mappingInfo)
        {
            return new SqlServerDateTypeMapping();
        }
        public override RelationalTypeMapping Clone(string storeType, int? size)
        {
            return new SqlServerDateTypeMapping();
        }
        public override CoreTypeMapping Clone(ValueConverter converter)
        {
            return new SqlServerDateTypeMapping();
        }
    }
