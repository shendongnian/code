    [Key]
    public Guid LocationID { get; set; } = Guid.NewGuid();
    public string Description { get; set; }
    public ICollection<Event> Events {get; set;}
    modelBuilder.Entity<Event>()
            .HashMany<Location>(e = > e.Events)
            .WithRequired(l => l.Location)
            .WillCascadeOnDelete();
