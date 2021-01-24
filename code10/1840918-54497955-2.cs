    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
    //#warning To protect potentially sensitive information in your
    // connection string, you should move it out of source code.
    // See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=MyDb;Trusted_Connection=True;");
        }
    }
