    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var props = from e in modelBuilder.Model.GetEntityTypes()
                    from p in e.GetProperties()
                    where p.Name == "Name"
                       && p.PropertyInfo.PropertyType == typeof(string)
                    select new { e, p };
        foreach (var ep in props)
        {
            ep.p.SetMaxLength(200);
            ep.p.IsNullable = false;
            ep.e.AddKey(ep.p);                
        }
        base.OnModelCreating(modelBuilder);
    }
