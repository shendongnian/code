class BetterPersonDal {
    private DbProviderFactory factory;
    private DbConnection connection;
    private DbCommand command;
    private DbParameter id;
    private DbParameter name;
    public BetterPersonDal(DbConnection connection) {
        this.command = connection.CreateCommand();
        this.command.CommandText = "Whatever";
        this.command.CommandType = CommandType.StoredProcedure;
        this.id = command.CreateParameter();
        this.id.ParameterName = "@Id";
        this.id.DbType = DbType.Int32;
        this.name = command.CreateParameter();
        this.name.ParameterName = "@Name";
        this.name.DbType = DbType.String;
        this.name.Size = 50;
        this.command.Parameters.AddRange(new DbParameter[] { id, name });
    }
    public int Insert(Person person) {
        this.id.Value = person.Id;
        this.name.Value = person.Name;
        return (int)command.ExecuteScalar();
    }
}
