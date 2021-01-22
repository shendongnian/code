        [Required]
        public virtual int PhoneTypeId
        {
            get
            {
                return (int)this.PhoneType;
            }
            set
            {
                PhoneType = (PhoneTypes)value;
            }
        }
        [EnumDataType(typeof(PhoneTypes))]
        public PhoneTypes PhoneType { get; set; }
    public enum PhoneTypes
    {
        Mobile = 0,
        Home = 1,
        Work = 2,
        Fax = 3,
        Other = 4
    }
