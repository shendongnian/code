    private DateTime? _joinedDate;
    [Column(TypeName = "DateTime2")]
    public DateTime JoinedDate
    {
        get { return _joinedDate ?? DateTime.Now; }
        set { _joinedDate = value; }
    }
