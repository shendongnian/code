    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connstr = ConfigurationManager.ConnectionStrings["InzerceConnection"].ToString();
            optionsBuilder.UseSqlServer(connstr);
        }
