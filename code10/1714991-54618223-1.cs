    public class SqlServerIPointTypeConverter : OrmLiteConverter
    {
        public override string ColumnDefinition => "geography";
        public override DbType DbType => DbType.Object;
        public override string ToQuotedString(Type fieldType, object value)
        {
            if (fieldType != typeof(IPoint)) return base.ToQuotedString(fieldType, value);
            string str = null;
            if (value != null)
            {
                var geo = (IPoint) value;
                str = geo.ToString();
            }
            str = (str == null) ? "null" : $"'{str}'";
            return $"CAST({str} AS {ColumnDefinition})";
        }
        public override void InitDbParam(IDbDataParameter p, Type fieldType)
        {
            if (fieldType == typeof(IPoint))
            {
                var sqlParam = (SqlParameter)p;
                sqlParam.IsNullable = fieldType.IsNullableType();
                sqlParam.SqlDbType = SqlDbType.Udt;
                sqlParam.UdtTypeName = ColumnDefinition;
            }
            base.InitDbParam(p, fieldType);
        }
        public override object FromDbValue(Type fieldType, object value)
        {
            switch (value)
            {
                case null:
                case DBNull _:
                    return new Point(0, 0);
                case IPoint point:
                    return point;
                case string _:
                    return Parse(value.ToString());
                default:
                    return base.FromDbValue(fieldType, value);
            }
        }
        public override object ToDbValue(Type fieldType, object value)
        {
            switch (value)
            {
                case null:
                case DBNull _:
                    return new Point(0, 0);
                case IPoint _:
                    return value;
                case string str:
                    return Parse(str);
                default:
                    return base.ToDbValue(fieldType, value);
            }
        }
        private static Point Parse(string rawPoint)
        {
            var split = rawPoint.Replace("POINT (", string.Empty)
                .Replace(")", string.Empty)
                .Trim()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var longitude = Convert.ToDouble(split[0]);
            var latitude = Convert.ToDouble(split[1]);
            return new Point(longitude, latitude);
        }
    }
