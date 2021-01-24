     public class Cargo
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int CargoID { get; set; }//SerialNo
            [Required]
            public DateTime DateOfPassage { get; set; }
            public string CompanyUserName { get; set; }
            public virtual ContainerIn CompanyUserNameContainIn { get; set; }
        }
    
        public class ContainerIn
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ContainerInID { get; set; }        
            public int LoadStatus { get; set; }        
            public int CargoID { get; set; }        
            public virtual Cargo Cargo { get; set; }
        }
