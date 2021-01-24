        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var props = from e in modelBuilder.Model.GetEntityTypes()
                        from p in e.GetProperties()
                        where p.Name == "Name"
                           && p.PropertyInfo.PropertyType == typeof(string)
                        select p;
            foreach (var p in props)
            {
                p.SetMaxLength(200);
                p.IsNullable = false;
                p.DeclaringEntityType.AddKey(p);
            }
            base.OnModelCreating(modelBuilder);
        }
