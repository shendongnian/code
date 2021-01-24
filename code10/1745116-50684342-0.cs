    public class TraductionInterface
    {
        [Key]
        public int TraductionInterfaceID {get; set; }
        public int DocTypeNameId {get; set; }
        [ForeignKey("DocTypeNameId")]
        public virtual DocType DocTypeName { get; set; }
        public int DocTypeValidationTextId {get; set; }
        [ForeignKey("DocTypeValidationTextId")]
        public virtual DocType DocTypeValidationText { get; set; }
     } 
