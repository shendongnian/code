    public class EmployeeLogReportListViewModel
    {
        public DateTime Date { get; set; }
        public int EmployeeID { get; set; }
        public TimeSpan Time { get; set; }
        public int Sort { get; set; }
        public string Employer { get; set; }
        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4}", this.Date, this.EmployeeID, this.Time, this.Sort, this.Employer);
        }
    }
