    public sealed class DbData: IDisposable
    {
        public DbData(DbDataReader reader, DbCommand command)
        {
            Reader  = reader;
            Command = command;
        }
        public void Dispose()
        {
            Reader.Dispose();
            Command.Dispose();
        }
        public DbDataReader Reader  { get; }
        public DbCommand    Command { get; }
    }
