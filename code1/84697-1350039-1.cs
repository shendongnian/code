class PersonDal {
    public int Insert(Person person) {
        DbProviderFactory factory = SqlClientFactory.Instance;
        using (DbConnection connection = factory.CreateConnection()) {
            connection.Open();
            connection.ConnectionString = "Whatever";
            using (DbCommand command = connection.CreateCommand()) {
                command.CommandText = "Whatever";
                command.CommandType = CommandType.StoredProcedure;
                DbParameter id = command.CreateParameter();
                id.ParameterName = "@Id";
                id.DbType = DbType.Int32;
                id.Value = person.Id;
                DbParameter name = command.CreateParameter();
                name.ParameterName = "@Name";
                name.DbType = DbType.String;
                name.Size = 50;
                name.Value = person.Name;
                command.Parameters.AddRange(new DbParameter[] { id, name });
                return (int)command.ExecuteScalar();
            }
        }
    }
}
