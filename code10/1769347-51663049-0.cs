    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
