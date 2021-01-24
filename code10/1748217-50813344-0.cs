    [Key]
    [Column(Order=1)]
    public string LoginProvider { get; set; }
    [Key]
    [Column(Order=2)]
    public string ProviderKey { get; set; }
    [Key]
    [Column(Order=3)]
    public string UserId { get; set; }
    public virtual User User { get; set; }
