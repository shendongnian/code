    protected override void OnModelCreating( DbModelBuilder model_builder )
    {
        base.OnModelCreating( model_builder );
        model_builder.Entity<TestTable>().HasKey(
            t => new { t.Id }
        );
    }
