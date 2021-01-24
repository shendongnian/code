    public static class DbUpHelper
    {
        public static UpgradeEngineBuilder WithReadOnlyJournal(this UpgradeEngineBuilder builder, string schema, string table)
        {
            builder.Configure(c => c.Journal = new ReadOnlyJournal(new SqlTableJournal(() => c.ConnectionManager, () => c.Log, schema, table)));
            return builder;
        }
    }
