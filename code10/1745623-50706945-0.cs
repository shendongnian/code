    public class SomeModel
    {
        public DateTime StartDate { get; set; }
        public bool IsActive
        {
            get { return DateTime.Now >= StartDate; }
        }
    }
