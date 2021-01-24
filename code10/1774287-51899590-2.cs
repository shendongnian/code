    public class CustomDbContext : DbContext
    {
        // …
    
        private string customTableName;
        public string CustomTableName => customTableName ?? "DefaultCustomTableName";
    }
