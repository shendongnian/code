    public class Employment
    {
        public int EmploymentID { get; set; }
        ...
        public Position Position { get; set; }
        [Required] // <--
        public Employee Employee { get; set; }
    }
