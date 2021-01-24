    public abstract class PMBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ProjectID { get; set; }
        [NotMapped]
        public virtual int? PMGroupID { get { return ProgramIDGetter(); } }
        public abstract int? ProgramIDGetter();
        
    //Omitted rest of Model
    }
