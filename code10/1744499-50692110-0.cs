    namespace Model
    {
        [Serializable]
        [Table("PROVISION")]
        public class Provision
        {
            [Key, Column("ID_PROVISION", Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public virtual long Id { get; set; }
    
            [Key,Column("ID_PROVISION_TYPE")]
            public virtual int IdProvisionType { get; set; }
    
            [ForeignKey("IdProvisionType")]
            public virtual ProvisionType ProvisionType { get; set; }
        }
    
        public class ProvisionType 
        {
            [Key, Column("ID_PROVISION_TYPE", Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
        }
    }
