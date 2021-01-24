    public class StudentVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Please select an attendance taker")]
        public int? SelectedAttendanceTaker { get; set; }
    }
    public class AttendanceTakerVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class StudentAttendanceTakersVM
    {
        public List<StudentVM> Students { get; set }
        public IEnumerable<AttendanceTakerVM> AttendanceTakers { get; set; }
    }
