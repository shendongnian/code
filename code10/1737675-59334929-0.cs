    protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                if (options != null)
                {
                    options.UseMemoryCache(_cache);
                }
            }
