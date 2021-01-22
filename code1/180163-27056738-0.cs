        private static string ConvertToJetDataType(int oleDbDataType)
        {
            switch (((OleDbType)oleDbDataType))
            {
                case OleDbType.LongVarChar:
                    return "varchar";
                case OleDbType.BigInt:
                    return "int";       // In Jet this is 32 bit while bigint is 64 bits
                case OleDbType.Binary:
                case OleDbType.LongVarBinary:
                    return "binary";
                case OleDbType.Boolean:
                    return "bit";
                case OleDbType.Char:
                    return "char";
                case OleDbType.Currency:
                    return "decimal";
                case OleDbType.DBDate:
                case OleDbType.Date:
                case OleDbType.DBTimeStamp:
                    return "datetime";
                case OleDbType.Decimal:
                case OleDbType.Numeric:
                    return "decimal";
                case OleDbType.Double:
                    return "double";
                case OleDbType.Integer:
                    return "int";
                case OleDbType.Single:
                    return "single";
                case OleDbType.SmallInt:
                    return "smallint";
                case OleDbType.TinyInt:
                    return "smallint";  // Signed byte not handled by jet so we need 16 bits
                case OleDbType.UnsignedTinyInt:
                    return "byte";
                case OleDbType.VarBinary:
                    return "varbinary";
                case OleDbType.VarChar:
                    return "varchar";
                case OleDbType.BSTR:
                case OleDbType.Variant:
                case OleDbType.VarWChar:
                case OleDbType.VarNumeric:
                case OleDbType.Error:
                case OleDbType.WChar:
                case OleDbType.DBTime:
                case OleDbType.Empty:
                case OleDbType.Filetime:
                case OleDbType.Guid:
                case OleDbType.IDispatch:
                case OleDbType.IUnknown:
                case OleDbType.UnsignedBigInt:
                case OleDbType.UnsignedInt:
                case OleDbType.UnsignedSmallInt:
                case OleDbType.PropVariant:
                default:
                    throw new ArgumentException(string.Format("The data type {0} is not handled by Jet. Did you retrieve this from Jet?", ((OleDbType)oleDbDataType)));
            }
        }
