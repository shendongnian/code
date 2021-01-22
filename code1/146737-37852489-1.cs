    [Required]
    public string PhoneTypeAsString
    {
        get
        {
            return this.PhoneType.ToString();
        }
        set
        {
            PhoneType = (PhoneTypes)Enum.Parse( typeof(PhoneTypes), value, true);
        }
    }
        
    public PhoneTypes PhoneType{get; set;};
    
    public enum PhoneTypes
    {
        Mobile = 0,
        Home = 1,
        Work = 2,
        Fax = 3,
        Other = 4
    }
