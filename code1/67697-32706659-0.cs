        public static Type GetClrType(SqlDbType sqlType, bool isNullable)
        {
            switch (sqlType)
            {
                case SqlDbType.BigInt:
                    return isNullable ? typeof(long?) : typeof(long);
                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.VarBinary:
                    return typeof(byte[]);
                case SqlDbType.Bit:
                    return isNullable ? typeof(bool?) : typeof(bool);
                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar:
                case SqlDbType.Xml:
                    return typeof(string);
                case SqlDbType.DateTime:
                case SqlDbType.SmallDateTime:
                case SqlDbType.Date:
                case SqlDbType.Time:
                case SqlDbType.DateTime2:
                    return isNullable ? typeof(DateTime?) : typeof(DateTime);
                case SqlDbType.Decimal:
                case SqlDbType.Money:
                case SqlDbType.SmallMoney:
                    return isNullable ? typeof(decimal?) : typeof(decimal);
                case SqlDbType.Float:
                    return isNullable ? typeof(double?) : typeof(double);
                case SqlDbType.Int:
                    return isNullable ? typeof(int?) : typeof(int);
                case SqlDbType.Real:
                    return isNullable ? typeof(float?) : typeof(float);
                case SqlDbType.UniqueIdentifier:
                    return isNullable ? typeof(Guid?) : typeof(Guid);
                case SqlDbType.SmallInt:
                    return isNullable ? typeof(short?) : typeof(short);
                case SqlDbType.TinyInt:
                    return isNullable ? typeof(byte?) : typeof(byte);
                case SqlDbType.Variant:
                case SqlDbType.Udt:
                    return typeof(object);
                case SqlDbType.Structured:
                    return typeof(DataTable);
                case SqlDbType.DateTimeOffset:
                    return isNullable ? typeof(DateTimeOffset?) : typeof(DateTimeOffset);
                default:
                    throw new ArgumentOutOfRangeException("sqlType");
            }
        }
