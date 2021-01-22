    using System;
    using SubSonic;
    namespace MyNamespace.ExtensionMethods
    {
    public static class SubsonicSqlQueryExtensionMethods
    {
        public static String BuildSqlStatementDebug(this SqlQuery qry)
        {
            var result = qry.BuildSqlStatement();
            foreach (var c in qry.Constraints)
            {
                            
                if (c.Comparison == Comparison.BetweenAnd)
                {
                    result = result.Replace(c.ParameterName + "_start", GetFormattedValue(c.StartValue, c.DbType));
                    result = result.Replace(c.ParameterName + "_end", GetFormattedValue(c.EndValue, c.DbType));
                }
                else
                {
                    result = result.Replace(c.ParameterName, GetFormattedValue(c.ParameterValue, c.DbType));
                }
            }
            return result;
        }
        // Works for MySQL
        private static readonly String formatter_date = "'{0:yyyy-MM-dd}'";
        private static readonly String formatter_datetime = "'{0:yyyy-MM-dd hh:mm:ss}'";
        private static readonly String formatter_string = "'{0}'";
        private static String GetFormattedValue(Object value, System.Data.DbType type)
        {
            switch (type)
            {
                case System.Data.DbType.AnsiString:
                    return String.Format(formatter_string, value);
                case System.Data.DbType.AnsiStringFixedLength:
                    return String.Format(formatter_string, value);
                //case System.Data.DbType.Binary:
                //    break;
                case System.Data.DbType.Boolean:
                    return (Boolean)value == true ? "true" : "false";
                //case System.Data.DbType.Byte:
                //    break;
                //case System.Data.DbType.Currency:
                //    break;
                case System.Data.DbType.Date:
                    return String.Format(formatter_date, value); break;
                case System.Data.DbType.DateTime:
                    return String.Format(formatter_datetime, value); break;
                case System.Data.DbType.DateTime2:
                    return String.Format(formatter_datetime, value); break;
                //case System.Data.DbType.DateTimeOffset:
                //    break;
                //case System.Data.DbType.Decimal:
                //    break;
                //case System.Data.DbType.Double:
                //    break;
                case System.Data.DbType.Guid:
                    return String.Format(formatter_string, value);
                //case System.Data.DbType.Int16:
                //    break;
                //case System.Data.DbType.Int32:
                //    break;
                //case System.Data.DbType.Int64:
                //    break;
                //case System.Data.DbType.Object:
                //    break;
                //case System.Data.DbType.SByte:
                //    break;
                //case System.Data.DbType.Single:
                //    break;
                case System.Data.DbType.String:
                    return String.Format(formatter_string, value);
                case System.Data.DbType.StringFixedLength:
                    return String.Format(formatter_string, value);
                //case System.Data.DbType.Time:
                //    break;
                //case System.Data.DbType.UInt16:
                //    break;
                //case System.Data.DbType.UInt32:
                //    break;
                //case System.Data.DbType.UInt64:
                //    break;
                //case System.Data.DbType.VarNumeric:
                //    break;
                case System.Data.DbType.Xml:
                    return String.Format(formatter_string, value);
                default:
                    return value.ToString();
            }
        }
    }
    }
