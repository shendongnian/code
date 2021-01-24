    public class Example
    {
        //ohter properties
        [Column("id_reference")
        public int IdReference { get; set; }
    
        [ForeignKey("IdReference ")]
        public virtual Reference ReferenceObj { get; set; }
    }
        
