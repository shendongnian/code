        public class Cargo
        {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int CargoID { get; set; }//SerialNo
          [Required]
          public DateTime DateOfPassage { get; set; }
          public string CompanyUserName { get; set; }
          public int ContainerInId { get; set; } //need to define a foreign key. This is happening by naming convention in this case as with your `ContainerIn.CargoId` foreign key 
          public virtual ContainerIn ContainerIn { get; set; }
        }
        
        public class ContainerIn 
        {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int ContainerInID { get; set; }
          public int CargoID { get; set; }
          public virtual Cargo Cargo { get; set; }
          public int LoadStatus { get; set; }
        }
