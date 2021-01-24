    public abstract class CMEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public abstract decimal ID { get; set; }
        [StringLength(50)]
        public abstract string Name { get; set; }
        ....
    }
