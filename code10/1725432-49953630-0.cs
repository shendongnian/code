    public sealed class SecurityContext : ISecurityContext
    {
        private static readonly AsyncLocal<Database> db =
            new AsyncLocal<Database>();
        Database ISecurityContext.Database => db.Value;
        internal void SetDatabase(Database database) => db.Value = database;
    }
