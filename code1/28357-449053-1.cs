    public class SelectClassData
    {
        public int ClassID { get; set; }
        public string Title { get; set; }
        public DateTime sDate { get; set; }
        public DateTime eDate { get; set; }
        public string StartDate { get { return GetSDate(); } }
        public string EndDate { get { return GetEDate(); } }
        public string TimeOfClass { get { return GetTimeOfClass(); } }
     
        protected string GetSDate()
        {
            return sDate.ToShortDateString();
        }
    
        protected string GetEDate()
        {
            return eDate.ToShortDateString();
        }
    
        protected string GetTimeOfClass()
        {
            return sDate.ToShortTimeString() + " - " + eDate.ToShortTimeString();
        }
    }
