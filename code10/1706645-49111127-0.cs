    modelBuilder.Entity<ChecklistAndItem>()
    	.Property<int>("ChecklistID");
    modelBuilder.Entity<ChecklistAndItem>()
    	.Property<int>("ChecklistItemID");
    modelBuilder.Entity<ChecklistAndItem>()
    	.HasKey("ChecklistID", "ChecklistItemID");
