    public abstract class Database
    {
        private readonly DbProviderFactory factory;
        protected Database(DbProviderFactory factory)
        {
            this.factory = factory;
        }
        public virtual DbCommand CreateCommand(String commandText)
        {
            return CreateCommand(CommandType.Text, commandText);
        }
        public virtual DbCommand CreateCommand(CommandType commandType, String commandText)
        {
            DbCommand command = factory.CreateCommand();
            command.CommandType = commandType;
            command.Text = commandText;
            return command;
        }
        public virtual void BindParametersByName(DbCommand command)
        {
        }
    }
