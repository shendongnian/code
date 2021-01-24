    public DbData GetReader(string sql)
    {
        DbDataReader reader = ...;
        DbCommand command   = ...;
        return new DbData(reader, command);
    }
