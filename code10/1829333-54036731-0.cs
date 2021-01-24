    public class Device
    {
        [Required]
        [DataMember(Name = "key")]
        [Key]
        public Guid Key { get; set; }
     
        [ForeignKey("DeviceType")]   
        public Guid DeviceTypeId { get; set; } // I assumed primary key of your `DeviceType` entity is `Guid`
        [ForeignKey("ModelType")]  
        public Guid ModelTypeId { get; set; } // I assumed primary key of your `ModelType` entity is `Guid`
    
        
        [IgnoreDataMember]
        public virtual DeviceType DeviceType { get; set; }
    
        
        [IgnoreDataMember]
        public virtual ModelType ModelType { get; set; }
    }
