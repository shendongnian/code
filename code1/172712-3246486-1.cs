    public static partial class ObjectContextExtension
    {
        public static T ExecuteScalarCommand<T>(this ObjectContext context, string command)
        {
            DbConnection connection = ((EntityConnection)context.Connection).StoreConnection;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
    
            DbCommand cmd = connection.CreateCommand();
            cmd.CommandText = command;
            cmd.CommandType = CommandType.Text;
            return (T)cmd.ExecuteScalar();
        }
