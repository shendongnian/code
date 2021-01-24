    public class simStaff
    {
        [Key]
        public int simStaffId { get; set; }
        [Required(ErrorMessage ="You must enter a first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="You must enter a last name")]
        public string LastName { get; set; }
        public ICollection<simHoursRecorded> simHoursRecorded { get; set; }
        public ICollection<simPayRate> simPayRate { get; set; }
    }
    public class simHoursRecorded
    {
        [Key]
        public int simHoursRecordId { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DayWorked { get; set; }
        public int HoursBooked { get; set; }
        public bool AuthorisedToPay { get; set; }
        public int simStaffId { get; set; }
        public simStaff simStaff;
    }
    public class simPayRate
    {
        [Key]
        public int simPayRateId { get; set; }
        public double RatePerHour { get; set; }
        public DateTime DateAppliesFrom { get; set; }
        public int? simHoursTypeId { get; set; }       
        public simHoursType simHoursType { get; set; }
        public int simStaffId { get; set; }
        public simStaff simStaff;
    }
    public class simHoursType
    {
        [Key]
        public int simHoursTypeId { get; set; }
        public string HoursType { get; set; }
        public ICollection<simHoursType> simPayRate { get; set; }
    }
