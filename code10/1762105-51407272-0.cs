    //Dependent
    public class TrainerProfile : BaseEntity<int>
    {   
        protected TrainerProfile() //***Changed from private to protected***
        {
        } 
        protected TrainerProfile(int id) : base(id)
        {
        }
        [Key]
        [Column("TrainerID")]
        public override int Id { get; protected set; }
        public bool Passport { get; set; }
        [StringLength(1000)]
        public string SpecialConsiderations { get; set; }
        [StringLength(10)]
        public string SeatPreference { get; set; }
        [ForeignKey("Id")]
        public virtual Employee Employee { get; set; }
    }
