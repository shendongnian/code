    public class Travel
    {
        public Travel(string where, DateTime start, DateTime end)
        {
            Where = where;
            StartDate = start;
            EndDate = end;
        }
        public string Where { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
