    CREATE TABLE Slaves (
        SlavesId INT NOT NULL IDENTITY PRIMARY KEY,
        MasterId VARCHAR2 NOT NULL,
        Discriminator VARCHAR2 NOT NULL,
        SlaveAValue VARCHAR2,
        SlaveBValue VARCHAR2,
        FOREIGN KEY (MasterId) REFERENCES Master(Id) ON DELETE CASCADE
    );
    [Table("Slaves")]
    public abstract class Slave
    {
    
        [Column("SlaveId")]
        [Key]
        public int SlaveId {get;set;}
    
        [Column("MasterId")]
        [Required]
        public string MasterId { get; set; }
    
        [ForeignKey("MasterId")]
        public Master Master { get; set; }
    }
