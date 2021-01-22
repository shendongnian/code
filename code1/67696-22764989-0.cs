        internal Type type(SqlDbType sqltype)
        {
            Type resulttype = null;
            Dictionary<SqlDbType, Type> Types = new Dictionary<SqlDbType, Type>();
            Types.Add(SqlDbType.BigInt, typeof(Int64));
            Types.Add(SqlDbType.Binary, typeof(Byte[]));
            Types.Add(SqlDbType.Bit, typeof(Boolean));
            Types.Add(SqlDbType.Char, typeof(String));
            Types.Add(SqlDbType.Date, typeof(DateTime));
            Types.Add(SqlDbType.DateTime, typeof(DateTime));
            Types.Add(SqlDbType.DateTime2, typeof(DateTime));
            Types.Add(SqlDbType.DateTimeOffset, typeof(DateTimeOffset));
            Types.Add(SqlDbType.Decimal, typeof(Decimal));
            Types.Add(SqlDbType.Float, typeof(Double));
            Types.Add(SqlDbType.Image, typeof(Byte[]));
            Types.Add(SqlDbType.Int, typeof(Int32));
            Types.Add(SqlDbType.Money, typeof(Decimal));
            Types.Add(SqlDbType.NChar, typeof(String));
            Types.Add(SqlDbType.NText, typeof(String));
            Types.Add(SqlDbType.NVarChar, typeof(String));
            Types.Add(SqlDbType.Real, typeof(Single));
            Types.Add(SqlDbType.SmallDateTime, typeof(DateTime));
            Types.Add(SqlDbType.SmallInt, typeof(Int16));
            Types.Add(SqlDbType.SmallMoney, typeof(Decimal));
            Types.Add(SqlDbType.Text, typeof(String));
            Types.Add(SqlDbType.Time, typeof(TimeSpan));
            Types.Add(SqlDbType.Timestamp, typeof(Byte[]));
            Types.Add(SqlDbType.TinyInt, typeof(Byte));
            Types.Add(SqlDbType.UniqueIdentifier, typeof(Guid));
            Types.Add(SqlDbType.VarBinary, typeof(Byte[]));
            Types.Add(SqlDbType.VarChar, typeof(String));
            Types.TryGetValue(sqltype, out resulttype);
            return resulttype;
        }
        internal SqlDbType type(Type systype)
        {
            SqlDbType resulttype = SqlDbType.NVarChar;
            Dictionary<Type, SqlDbType> Types = new Dictionary<Type, SqlDbType>();
            Types.Add(typeof(Boolean), SqlDbType.Bit);
            Types.Add(typeof(String), SqlDbType.NVarChar);
            Types.Add(typeof(DateTime), SqlDbType.DateTime);
            Types.Add(typeof(Int16), SqlDbType.Int);
            Types.Add(typeof(Int32), SqlDbType.Int);
            Types.Add(typeof(Int64), SqlDbType.Int);
            Types.Add(typeof(Decimal), SqlDbType.Float);
            Types.Add(typeof(Double), SqlDbType.Float);
            Types.TryGetValue(systype, out resulttype);
            return resulttype;
        }
