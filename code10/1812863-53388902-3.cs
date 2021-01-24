    [Index("IX_UniqueConstraint", 1, IsUnique = true)]
    public string FirstName { get; set; }
    
    [Index("IX_UniqueConstraint", 2, IsUnique = true)]
    public string LastName { get; set; }
    
    [Index("IX_UniqueConstraint", 3, IsUnique = true)]
    public DateTime DateOfBirth { get; set; }
