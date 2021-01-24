    public class SlaveA : Slave
    {
        public string Discriminator => "S1";
    
        [Column("SlaveAValue")]
        [Required]
        public string SlaveAValue { get; set; }
    }
    
    public class SlaveB : Slave
    {
        public string Discriminator => "S2";
    
        [Column("SlaveBValue")]
        [Required]
        public string SlaveBValue { get; set; }
    }
