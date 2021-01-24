    [NotMapped]
    public override int Id
    {
    	get
    	{
    		return PKColumn;
    	}
    	set
    	{
    		PKColumn = value;
    	}
    }
    
    [Key]
    public virtual int PKColumn { get; set; }
