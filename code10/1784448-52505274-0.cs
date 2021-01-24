    public class Municipality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }
        public string Name { get; set; }
        public DbGeography Area { get; set; }
        [ForeignKey("County")]
        public string CountyCode { get; set; }
        public virtual County County { get; set; }
    }
