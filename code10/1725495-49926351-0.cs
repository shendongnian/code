    modelBuilder.Entity<MyObject>(builder =>
    {
    	builder.Property(e => e.Prop7).Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
    	builder.Property(e => e.Prop8).Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
    	builder.Property(e => e.Prop9).Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
    });
