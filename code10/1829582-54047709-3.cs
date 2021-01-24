        public static SqlParameter CreateTableValuedParameter(string typeName, string parameterName)
        {
            // Exceptions are handled by the caller
            var oParameter = new SqlParameter();
            oParameter.ParameterName = parameterName;
            oParameter.SqlDbType = SqlDbType.Structured;
            oParameter.TypeName = typeName;
            return oParameter;
        }
