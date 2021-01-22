        public static DbParameter AddParameter(this DbCommand command, string name, DbType dbType)
        {
            DbParameter p = AddParameter(command, name, dbType, 0, ParameterDirection.Input);
            return p;
        }
        public static DbParameter AddParameter(this DbCommand command, string name, DbType dbType, object value)
        {
            DbParameter p = AddParameter(command, name, dbType, 0, ParameterDirection.Input);
            p.Value = value;
            return p;
        }
        public static DbParameter AddParameter(this DbCommand command, string name, DbType dbType, int size)
        {
            return AddParameter(command, name, dbType, size, ParameterDirection.Input);
        }
        public static DbParameter AddParameter(this DbCommand command, string name, DbType dbType, int size, ParameterDirection direction)
        {
            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.DbType = dbType;
            parameter.Direction = direction;
            parameter.Size = size;
            command.Parameters.Add(parameter);
            return parameter;
        }
