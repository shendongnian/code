    public class FDTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }     
        .... (your other properties here, same as before) ......  
    }
