    public class Month
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
    public class ViewModel
    {
        public List<Month> Months { get; } = new List<Month>
        {
            new Month { Name="January" },
            new Month { Name="February" },
            new Month { Name="March" },
            new Month { Name="April" },
            new Month { Name="May" },
            new Month { Name="June" },
            new Month { Name="July" },
            new Month { Name="August" },
            new Month { Name="September" },
            new Month { Name="October" },
            new Month { Name="November" },
            new Month { Name="December" },
        };
        public IEnumerable<Month> SelectedMonths
        {
            get { return Months.Where(m => m.IsSelected); }
        }
    }
