    public class OracleDatabase : Database
    {
        public OracleDatabase()
            : base(OracleClientFactory.Instance)
        {
        }
        public override DbCommand CreateCommand(CommandType commandType, String commandText)
        {
            DbCommand command = base.CreateCommand(commandType, commandText);
            BindParametersByName(command);
            return command;
        }
        public override void BindParametersByName(DbCommand command)
        {
            ((OracleCommand)command).BindByName = true;
        }
    }
