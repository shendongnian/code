    public class SectionID
    {
        public int SectionID { get; set; }
    }
    
    public class RootObject
    {
        public string Status { get; set; }
        public int ScheduleID { get; set; }
        public List<SectionID> SectionID { get; set; }
    }
