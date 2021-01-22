    [Required]
        public virtual int PhoneTypeId { get; set; }
        [EnumDataType(typeof(PhoneTypes))]
        public PhoneTypes PhoneType
        {
            get
            {
                return (PhoneTypes)this.PhoneTypeId;
            }
            set
            {
                this.PhoneTypeId = (int)value;
            }
        }
 
